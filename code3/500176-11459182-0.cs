    string someTextToSet = "this should be the new text";
    if (c is ITextControl)
    {
       ((ITextControl)c).Text = someTextToSet;
    }
    else if (c is HtmlInputControl)
    {
       ((HtmlInputControl)c).Value = someTextToSet;
    }
    else if (c is HiddenField)
    {
       ((HiddenField)c).Value = someTextToSet;
    }
