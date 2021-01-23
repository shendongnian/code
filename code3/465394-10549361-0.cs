    <body dir="<%:Dir%>">
    public string Dir { get; set; }
    // Set Dir in the on click event
    protected void RequestLanguageChange_Click(object sender, EventArgs e)
    {
        LinkButton senderLink = sender as LinkButton;
    
        //store requested language as new culture in the session
        if (senderLink.CommandArgument == "he-IL")
        {
            Dir = "rtl";
        }
        else
        {
            Dir = "ltr";
        }
        Session[Global.SESSION_KEY_CULTURE] = senderLink.CommandArgument;
    
        //reload last requested page with new culture
        Server.Transfer(Request.Path);
    
    }
