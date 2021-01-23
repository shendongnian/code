    void Page_Init()
    {
        Stack<string> history = Session["history"]; 
        if (history == null) history = new Stack<string>();
        history.Push(Request.Url.AbsoluteUri);
        Session["history"] = history;
    }
