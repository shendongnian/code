    public List<string> Code
    {
        get
        {
            if(HttpContext.Current.Session["Code"] == null)
            {
                HttpContext.Current.Session["Code"] = new List<string>();
            }
            return HttpContext.Current.Session["Code"] as List<string>;
        }
        set
        {
            HttpContext.Current.Session["Code"] = value;
        }
    
    }
