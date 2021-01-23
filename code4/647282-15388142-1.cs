    List<String> results = new List<String>();
    
    if (ctrl is Control)
    {
        Control c = (Control)ctrl;
        foreach (object innerCtrl in c.Controls)
        {
            if (innerCtrl is System.Web.UI.WebControls.CheckBox)
                if (((CheckBox)innerCtrl).Checked == true)
                {
                    //string resultado = (((CheckBox)innerCtrl).Text);
                    results.Add((((CheckBox)innerCtrl).Text));
                }
                else
                {
                    TextBox1.Text = "não";
                }
        }
    }
    
    if (results.Count > 0)
    {
        // We got results. Do something with our resaults.
        foreach (var result in results)
        {
            Console.Write(results);
        }
    }
