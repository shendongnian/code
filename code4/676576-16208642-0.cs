    foreach(Control c in this.Controls)
    {
       if(c is RadioButton)
       {
         c.Checked = false;
       }
    }
    
    foreach(Control i in this.Controls)
    {
       if(i is CheckBox)
       {
         i.Checked = false;
       }
    }
