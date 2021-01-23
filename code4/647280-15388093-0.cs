    string resultado = null;
    if (ctrl is Control)
    {
        Control c = (Control)ctrl;
        foreach (object innerCtrl in c.Controls)
        {
            if (innerCtrl is System.Web.UI.WebControls.CheckBox)
            {
                if (((CheckBox)innerCtrl).Checked)
                {
                    resultado = (((CheckBox)innerCtrl).Text);
                }
                else
                {
                    TextBox1.Text = "não";
                }
            }
        }
    }
    if (resultado != null) /* use the variable */
