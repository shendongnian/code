    public static object Objects  
    {
        get
        {
            if (HttpContext.Current.Session["Objects"] != null)
                return (object)HttpContext.Current.Session["Objects"];
            else
            {
                var obj = new object();
                HttpContext.Current.Session["Objects"] = obj;
                return obj;
            }
        }
    
        set { HttpContext.Current.Session["Objects"] = value; }
    }
