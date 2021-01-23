    public void EditPanel(System.Web.UI.WebControls.Panel panel)
    {
        foreach (var t in panel.Controls)
        {
            if (t is System.Web.UI.WebControls.TextBox)
                ((System.Web.UI.WebControls.TextBox)t).Enabled = true;
        }
    }
