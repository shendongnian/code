      public class MyController : Controller{
         
           public ActionResult MyView(){
             return View(new MyViewModel 
                       { Action ="MyPartialView" , ControllerName = "my"});
           }
          
           public ActionResult MyPartialView(){
             return PartialView();
           }
      }
