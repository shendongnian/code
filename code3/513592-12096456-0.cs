    public class SessionController
        {
            public static string DOB
            {
                get
                {
                    if (HttpContext.Current.Session["DOB"] != null)
                    {
                        return HttpContext.Current.Session["DOB"].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    HttpContext.Current.Session["DOB"] = value;
    
                }
            }
        }
