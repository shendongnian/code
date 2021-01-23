    private List<string> Messages
    {
        get
        {
            var messages = Session["Messages"] as List<string>;
    
            if (messages == null)
            {
                messages = new List<string>();
                Session["Messages"] = messages;
            }
    
            return messages;
        }
    }
 
