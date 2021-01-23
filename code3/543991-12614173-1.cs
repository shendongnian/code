    void Back_Click()
    {
        Stack<string> history = Session["history"]; 
        if (history != null) 
        {
            string url = history.Pop();
            Session["history"] = history;
            Response.Redirect(url);
        }
    }
