    public static string UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] == null)
                {
                    return "";
                }
                return HttpContext.Current.Session["UserId"].ToString();
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
