    protected void Button2_Click(object sender, EventArgs e)
    {
        bool selected = false;
  
        if (ViewState["IsSelected"] != null)
        {
           selected = (bool) ViewState["IsSelected"];
        }
        if (!selected)
        {
            ViewState["IsSelected"] = true;
            Styles.buttonHighlight(Button2);
        }
        else
        {
            ViewState["IsSelected"] = false;
            Styles.buttonReset(Button2);
        }
    }  
