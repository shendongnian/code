    HtmlControl control = null;
    switch(varInput)
    {
        case "btn":
            control = new HtmlButton();
            break;
        case "lbl":
            control = new HtmlGenericControl();
            break;
    }
 
    if(control != null)
    {
        control.Style.Add("font-size", "14px");
        pnl.Controls.Add(control);
    }
