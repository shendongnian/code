       public class BaseController : Controller
       {
          protected override void ExecuteCore()
          {
             string cultureName = null;
             // Attempt to read the culture cookie from Request
             HttpCookie cultureCookie = Request.Cookies["_culture"];
             if (cultureCookie != null)
             {
                cultureName = cultureCookie.Value;
             }
             else
             {
                if (Request.UserLanguages != null)
                {
                   cultureName = Request.UserLanguages[0]; // obtain it from HTTP header AcceptLanguages
                }
                else 
                {
                   cultureName = "en-US"; // Default value
                }
             }
    
             // Validate culture name
             cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe
    
    
             // Modify current thread's cultures            
             Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
             Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
    
             base.ExecuteCore();
          }
       }
