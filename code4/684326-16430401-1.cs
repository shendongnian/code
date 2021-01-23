    public void MySub(string varInput, Panel pnl)
    {
        HtmlControl ctlHtml;
        switch(varInput)
        {
            case "btn":
                ctlHtml = new HtmlButton();
                break;
            case "lbl":
                ctlHtml = new HtmlGenericControl();
                break;
            default:
                ctlHtml = null;
                break;
        }
        if (ctlHtml != null)
        {
            ctlHtml.Style.Add("font-size", "14px");
            pnl.Controls.Add(ctlHtml);
        }
    }
