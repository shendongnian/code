    get
    {
        if(HttpContext.Current.Session["MyData"]==null)
        {
            HttpContext.Current.Session["MyData"] = new List<Message>();
        }
    
        List<Message> list = HttpContext.Current.Session["MyData"] as List<Message>;
    
        return list;
    }
