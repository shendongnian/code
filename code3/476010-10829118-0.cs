    public class HomeController : Controller
    {
        public class MyCustomView : IView
        {
            public void Render(ViewContext viewContext, System.IO.TextWriter writer)
            {
                writer.WriteLine("view's content");
            }
        }
        public ActionResult Index()
        {
            return View(new MyCustomView());
        }
    }
