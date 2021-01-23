    public class MyBaseController : Controller
    {
        private int? _yearId;
        
        protected int YearId
        {
            get
            {
                 // Only evaluate the first time the property is called
                 if (!_yearId.HasValue)
                 {
                     // HttpContext is accessible directly off of Controller
                     HttpCookie cookie = HttpContext.Request.Cookies["myCookie"];
    
                     //do something with cookie.Value
                     if (cookie!=null) 
                     {
                          _yearId = int.Parse(cookie.Value);
                     }
                     else
                     {
                          // do something here
                     }
                 }
                 return _yearId.Value;
            }
        }
    }
