    public class LoginController : Controller {
    	[HttpGet]
    	public ActionResult Login() {
    		return View();
    	}
    	
    	[HttpPost]
    	public ActionResult Login(LoginViewModel model) {
    		if( ModelState.IsValid ) {
    			if( Membership.ValidateUser(model.UserName, model.Password) ) {
    				FormsAuthentication.SetAuthCookie(model.UserName, false);
    				return Redirect("~/");
    			}
    		}
    		
    		// If we got this far, something went wrong.
    		// Pass the model back to the view.
    		return View(model);
    	}
    }
