    public static List<Message> SessionStore
    {
        get
        {
            if(HttpContext.Current.Session["MyData"]==null)
            {
                HttpContext.Current.Session["MyData"] = new List<Message>();
            }
            return _HttpContext.Current.Session["MyData"] as List<Message>;
        }
    }
