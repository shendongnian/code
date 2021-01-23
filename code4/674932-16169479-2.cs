    WebControl webControl = validateControl as WebControl;
    if (webControl != null)
    {
        // Here 'webControl' is surely _not_ null.
        webControl.CssClass = Page.IsValid ? "stack" : "overflow";
    }
