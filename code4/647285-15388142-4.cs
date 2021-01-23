    public List<String> FetchTextFromCheckBoxes(Control cntrl)
    {
        List<String> results = new List<String>();
    
        if (ctrl is Control)
        {
            Control c = (Control)ctrl;
            foreach (object innerCtrl in c.Controls)
            {
                if (innerCtrl is System.Web.UI.WebControls.CheckBox)
                    if (((CheckBox)innerCtrl).Checked == true)
                    {
                        string resultado = (((CheckBox)innerCtrl).Text);
                        if (!String.IsNullOrEmpty(resultado))
                            results.Add(resultado);
                    }
                    else
                    {
                        TextBox1.Text = "não";
                    }
            }
        }
    
        return results;
    }
