    public sealed class WebUser
    {
        public static WebUser Current
        {
            get
            {
                var session = HttpContext.Current.Session;
                if(session["user"] != null)
                    session["user"] = new WebUser();
                return (WebUser)session["user"];
            }
        }
    } // eo class WebUser
