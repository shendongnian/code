    public class HomeController : Controller
    {
        public Task<ViewResult> Index()
        {
            return Task.Factory.StartNew(() =>
            {
                var model = "use a provider, get some data, or something";
                return View(model);
            });
        }
    }
