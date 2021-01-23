    public class BaseController : Controller
    {
        public string ActiveLanguage { get; set; } 
            
        public BaseController()
        {
            if (HttpContext.Request != null && HttpContext.Request.Cookies != null)
            {
                // copy value from the correct cookie to variable
                var languageCookie = HttpContext.Request.Cookies.Get("name_of_the_cookie");
    
                ActiveLanguage = languageCookie != null ? languageCookie.Value : string.Empty;
            }
        }
    }
