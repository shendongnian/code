    int index = 0;
    // either form.Controls or this.Controls dedepnds on where you put this code
    foreach (var control in form.Controls)
    {
       var button = control as Button;
       if (button != null)
       {
          button.Text = String.Format("Button #{0}", index);     
          index++;
       }      
    }
