    public void FindTheControls(Control parent) 
    {
    foreach(var c in parent.Controls) 
    { 
     if(c is IControl) //Or whatever that is you checking for 
     {
       if (c is CheckBox && c.Checked)
       { 
          //Here you can get the text of the check box and insert into the DB
          continue;
       } 
       if(c.Controls.Count > 0) 
       {
           this.FindTheControls(c);
       }
      }
     }  
    }
