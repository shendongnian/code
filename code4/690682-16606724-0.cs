        foreach (Control c in rptItems.Items)
        {
            if(c.FindControl("tbSelected") != null)
            {
               var selectedText = ((TextBox)c.FindControl("tbSelected")).Text;
            }
        }
