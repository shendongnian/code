    protected void Page_Init(object sender, System.EventArgs e)
    {
        HtmlGenericControl css;
        css = new HtmlGenericControl();
        css.TagName = "style";
        css.Attributes.Add("type", "text/css");
        css.InnerHtml = "@import \"/foobar.css\";";
        Page.Header.Controls.Add(css);
    }
