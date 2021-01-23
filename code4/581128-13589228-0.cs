    public void EditPanel(System.Web.UI.WebControls.Panel panel)
    {
        foreach (var control t in panel.Controls)
        {
            System.Web.UI.WebControls.TextBox textBox = control as System.Web.UI.WebControls.TextBox;
            if (textBox != null)
            {
                control.Enabled = true;
            }    
        }
    }
