    public class AppManager
    {
        public static RequestObject RequestObject
        {
            get
            {
                if (HttpContext.Current.Items["RequestObject"] == null)
                {
                    HttpContext.Current.Items["RequestObject"] = new RequestObject();
                }
                return (RequestObject)HttpContext.Current.Items["RequestObject"];
            }
            set { HttpContext.Current.Items["RequestObject"] = value; }
        }
    }
