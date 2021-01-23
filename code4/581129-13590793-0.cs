    public void EditPanel(System.Web.UI.WebControls.Panel panel)
    {
        foreach (Control c in panelId.Controls)
                {
                    if (c is HtmlGenericControl)
                    {
                        foreach (var textbox in c.Controls.OfType<TextBox>()) //ofType returns IEnumerable<TextBox>
                            textbox.Enabled = true;
                    }
                }
    } 
