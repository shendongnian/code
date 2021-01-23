    void Page_PreRender(object sender, EventArgs e)
    {
        foreach (string css in CssIncludes)
        {
            Page.Header.Controls.Add(new LiteralControl(string.Format("<link href='{0}' type='text/css' rel='stylesheet' />", (css))));
        }
    }
