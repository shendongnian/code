    public void Message(string msg)
    {
        ClientScript.RegisterStartupScript(Page, Page.GetType(), "msgid", "alert('" + msg + "')", true);
    }
    
    Message("Here comes the message");
