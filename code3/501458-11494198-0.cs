    public class ExampleController : Controller
    {
      private string ViewPath;
      public SomeController(string viewPath)
      {
         ViewPath = viewPath;
      }
    
      public ActionResult Index(ExampleModel exampleModel)
      {
         return View(ViewPath);
      }
    }
