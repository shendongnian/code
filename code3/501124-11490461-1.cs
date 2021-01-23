    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new[]
            {
                new Criterion { Text = "some integer", Value = 2 },
                new Criterion { Text = "some boolean", Value = true },
                new Criterion { Text = "some string", Value = "foo" },
            };
            return View(model);
        }
    }
