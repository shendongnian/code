    public class AuthController : Controller
    {
       	public ActionResult Index(Customer model)
    	{
    		if (ModelState.IsValid)
    		{
    			if (Membership.ValidateUser(model.userName, model.password))
    			{
    				if (Roles.IsUserInRole(model.userName, "admin")) return RedirectToAction("Index", "Product");
    				
    				return RedirectToAction("Index", "Home");
    			}
    			
    			ModelState.AddModelError("", "The user name or password is incorrect.");
    		}
    		// If we got this far, something failed, redisplay form
    		return View(model);	
    	}
    }
    
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
    	
        public ActionResult Index()
        {
    		return View();
    	}
    }
    
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
    	
    	public ActionResult Index()
    	{
    		return View();
    	}
    }
