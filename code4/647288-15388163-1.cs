    foreach (object innerCtrl in c.Controls)
    {
         if (innerCtrl is System.Web.UI.WebControls.CheckBox) {
    
            string resultado = string.Empty;
            if (((CheckBox)innerCtrl).Checked)
            {
                 resultado = (((CheckBox)innerCtrl).Text);
            }
            else
            {
               TextBox1.Text = "não";
            }
    
            //CAN READ variable here
         }
    }
