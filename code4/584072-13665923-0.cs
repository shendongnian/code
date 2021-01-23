    public void Page_Load(Object sender, EventArgs e)
    {
        // Define the name, type and url of the client script on the page.
        String csname = "ButtonClickScript";
        String csurl = "~/script_include.js";
        Type cstype = this.GetType();
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;
        // Check to see if the include script exists already.
        if (!cs.IsClientScriptIncludeRegistered(cstype, csname))
        {
            cs.RegisterClientScriptInclude(cstype, csname, ResolveClientUrl(csurl));
        }
    }
