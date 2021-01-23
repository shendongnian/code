    public class SomeController : Controller {
        
        [HttpGet]
        public ActionResult ChangePassword(string id){
            /* change password logic/domain calls */
            return View(/* some model */);
        }
    
    }
