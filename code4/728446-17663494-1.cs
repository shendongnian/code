    public class SomeController : Controller {
     [HttpPost]
     public ActionResult MyAction(FormCollection form){
      var toggle = form["autoreload"];
      var thevalue = form["value"];
     }
    }
