        public class LoginController : Controller
        {
               //make sure to name the parameter with the same name that you have passed as the route parameter on Response.RedirectToRoute method.
               public ActionResult Error(int code)
               {
                       ViewBag.ErrorCode = code;
 
                       ViewBag.ErrorMessage = EnumUtil.GetDescriptionFromEnumValue((Error)code);
 
                       return View();
               }
        }
