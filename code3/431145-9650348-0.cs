    public class HomeController
    {
       public ActionResult Index()
       {
          // Do something with model here, in this example we are creating a new model
          var model = new Model(); 
          // Send the model to the view, this is then available as @Model
          return View(model);
       }
    }
