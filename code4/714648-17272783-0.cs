    private btnSave_Click(object sender, EventArgs args)
    {
        //Save data
        ...
        string objectJson = GetJSON(); // {"userId": 100, "name": "John Smith"}
        ClientScriptManager cs = Page.ClientScript;
        StringBuilder cstext1 = new StringBuilder();
        cstext1.Append("<script type=text/javascript> window.opener.appendObject(" + objectJson  + ") </");
        cstext1.Append("script>");
        cs.RegisterStartupScript(this.GetType(), "RefreshScript", cstext1.ToString());
    }
