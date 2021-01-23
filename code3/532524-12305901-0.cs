    public class BaseController : Controller
    {
        public string UserLanguage
        {
            get
            {
                var cLanguage = HttpContext.Request.Cookies["lang"];
                if (cLanguage != null)
                    return cLanguage.Value;
                else
                    return "English";
            }
        }
    }
