    public class UserDC
    {
        public static string UserId
        {
            get
            {
                if(HttpContext.Current.Session["Test"] != null)
                    return HttpContext.Current.Session["Test"].ToString()
                else 
                    return "";
            }
            set
            {
                HttpContext.Current.Session["Test"] = value;
            }
        }
    }
