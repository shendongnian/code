    TextBox txt = new TextBox();
    txt.Text = "ABC";
    this.Controls.Add(txt);
    private void btnOk_Click(object sender, EventArgs e)
    {
    
     foreach (Control ctl in this.Controls)           
     {                              
      if (ctl.GetType() == typeof(TextBox))                               
        MessageBox.Show(ctl.Text);               
     }
    }
