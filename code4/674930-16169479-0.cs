    WebControl webControl = validateControl as WebControl;
    if (webControl != null)
    {
        webControl.CssClass = Page.IsValid ? "stack" : "overflow";
    }
