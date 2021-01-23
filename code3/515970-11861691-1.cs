    protected void Page_Load(object sender, EventArgs e)
    {
        string parameter = Request["__EVENTARGUMENT"];
        if (string.Equals("confirmed", 
                            parameter, 
                            StringComparison.InvariantCultureIgnoreCase))
        {
            // Call your server side method here
        }
    }
