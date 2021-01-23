    public class JobApplicantSession
     {
    
       // public JobApplication ApplicationSession
        public string ApplicationSession
        {
    
          get {   if (HttpContext.Current.Session["Application"] == null)
                  HttpContext.Current.Session["Application"] = new List<string>();
               return (List<string>)HttpContext.Current.Session["Application"];
          }
    
        }
    
    
    }
