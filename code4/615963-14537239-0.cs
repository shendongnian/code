    foreach(Control c in this.Controls) // this is the form object on which Controls is the ControlCollection
    {
       if(c is Button)
           c.BackColor = Color.White;
    }
