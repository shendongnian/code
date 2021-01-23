    protected void Page_Init(object sender, EventArgs e)
    { 
        HtmlLink css = new HtmlLink();
        css.Href = String.Format("{0}/css/style.css", GlobalVar.BasePath);
        css.Attributes["rel"] = "stylesheet";
        css.Attributes["type"] = "text/css";
        css.Attributes["media"] = "all";
        Page.Header.Controls.Add(css); 
    }
