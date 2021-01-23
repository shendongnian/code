    using System.Web;
    using System.Web.SessionState;
    using System.Collections.Generic;
    
    public static class ExampleSession
    {
        private static HttpSessionState session { get { return HttpContext.Current.Session; } }
    
        public static string UserName
        {
            get { return session["username"] as string; }
            set { session["username"] = value; }
        }
    
        public static List<string> ProductsSelected
        {
            get
            {             
                if (session["products_selected"] == null)
                    session["products_selected"] = new List<string>();
                
                return (List<string>)session["products_selected"];        
            }
        }
    }
