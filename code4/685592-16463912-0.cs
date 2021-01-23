    public string ID
        {
            get
            {
                if (System.Web.HttpContext.Current.Request.Headers.AllKeys.Contains("UID"))
                {
                     return System.Web.HttpContext.Current.Request.Headers["UID"].ToString();
                }
                else
                {
                    return "0000";
                }
                
            }
        }
