    protected void Page_Load(object sender, EventArgs e)
    {
        var control = FindHtmlControlByIdInControl(this, "button1");
        if (control != null)
        {
            control.Attributes["class"] = "someCssClass";
        }
    }
    private HtmlControl FindHtmlControlByIdInControl(Control control, string id)
    {
        foreach (Control childControl in control.Controls)
        {
            if (childControl.ID != null && childControl.ID.Equals(id, StringComparison.OrdinalIgnoreCase) && childControl is HtmlControl)
            {
                return (HtmlControl)childControl;
            }
            
            if (childControl.HasControls())
            {
                HtmlControl result = FindHtmlControlByIdInControl(childControl, id);
                if (result != null) return result;
            }
        }
        return null;
    }
