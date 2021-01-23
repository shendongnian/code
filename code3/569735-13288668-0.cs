    if(HttpContext.Current.Session["MyData"]==null)
    {
        _SessionStore = new List<Message>();
        // the following line is missing
        HttpContext.Current.Session["MyData"] = _SessionStore;
    }
