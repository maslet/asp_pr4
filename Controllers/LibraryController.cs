using Microsoft.AspNetCore.Mvc;

namespace usov_402_pr4.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IConfiguration _configuration;

        public LibraryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return Content("Ласкаво прошу до цієї бібліотеки! Хто входить тут, покинь усю надію");
        }

        public IActionResult Books()
        {
            var books = _configuration["Books"];
            return Content($"Книги в наявності: {books}");
        }

        public IActionResult Profile(int? id)
        {
            if (id.HasValue && id >= 0 && id <= 5)
            {
                var userKey = $"Users:{id}";
                var userInfo = _configuration[userKey];
                if (userInfo != null)
                {
                    return Content($"Про користувача з ID {id} є наступна інформація: {userInfo}");
                }
                return Content($"Користувача з ID {id.Value} не знайдено :(");
            }
            else
            {
                var currentUserInfo = _configuration["Users:CurrentUser"];
                return Content($"Інформація про поточного користувача: {currentUserInfo}");
            }
        }
    }
}
