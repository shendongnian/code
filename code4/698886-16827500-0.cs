    if(DDLCase.SelectedIndex == 0) // default value 
    {
       foreach (Control ctl in this.Controls)
       {
    
        if (ctl is Label)
          { 
           ctl.Text = "";
          }
    
       }
    }
       else
          {
           // code 
          }
