    protected void Page_Load(object sender, EventArgs e)
    {
        // Does the value exist in Session?
        if(null != Session["test"])
        {
            // No, so throw an exception
            throw new Exception();
        }
        // Grab the value from Session and cast it to a string
        var test = Session["test"] as string;
        // Is the string null or blank?
        if (string.IsNullOrWhiteSpace(test))
        { 
            // Yes, so give it a value of 'test' and redirect to another page
            Session["test"] = "test";
            Response.Redirect(Request.Path, false);
        } 
        else
        {
            // The value was not null or blank so rip it out of Session
            Session.Remove("test");    
        }
    }
