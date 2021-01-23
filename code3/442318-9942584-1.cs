    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var categories = new[]
            {
                new Categories { Id = 1, Name = "cat 1" },
                new VideoCategory { Id = 2, Name = "cat 2" },
            };
            var model = new MyViewModel
            {
                Categories = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
            return View(model);
        }
    }
