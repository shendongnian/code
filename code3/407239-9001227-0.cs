        public class CustomSessionObject
        {
            public string Name { get; set; }
        }
        [WebMethod]
        public static object GetSessionData()
        {
            try
            {
                return HttpContext.Current.Session["THE_SESSION_VAR_YOU_NEED"] as CustomSessionObject;
            }
            catch (Exception e)
            {
               //Log Exception
                throw;
            }
        }
