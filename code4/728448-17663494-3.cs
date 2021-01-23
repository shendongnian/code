    public class SomeController : Controller {
     [HttpPost]
     public ActionResult MyAction(MyModel model){
      var toggle = model.AutoReload;
      var thevalue = model.TheValue;
     }
    }
