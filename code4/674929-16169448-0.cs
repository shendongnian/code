    var webControl = validateControl as WebControl;
    if(webControl != null)
    {
        var cssClass = IsValid ? "stack" : "overflow";
        webControl.CssClass = cssClass;
    }
