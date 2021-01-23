    public class BaseController : Controller
    {
        protected override void ExecuteCore()
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            // If there is a cookie already with the language, use the value for the translation, else uses the default language configured.
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
            {
                cultureName = ConfigurationManager.AppSettings["DefaultCultureName"];
                cultureCookie = new HttpCookie("_culture");
                cultureCookie.HttpOnly = false; // Not accessible by JS.
                cultureCookie.Expires = DateTime.Now.AddYears(1);
            }
            // Validates the culture name.
            cultureName = CultureHelper.GetImplementedCulture(cultureName); 
            // Sets the new language to the cookie.
            cultureCookie.Value = cultureName;
            // Sets the cookie on the response.
            Response.Cookies.Add(cultureCookie);
            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            base.ExecuteCore();
        }
    }
