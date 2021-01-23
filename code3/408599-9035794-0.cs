    public MvcApplication()  // Constructor
    {
        this.BeginRequest += new EventHandler(MvcApplication_BeginRequest);
    }
    void MvcApplication_BeginRequest(object sender, EventArgs e)
    {
        Context.Items["LanguageId"] = 2;  // Store your language ID value here.
    }
