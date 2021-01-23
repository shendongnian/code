    foreach (Control c in parentForm.Controls)
    {
       if (c is Label && c.Name == "L")
       {
           // Do label stuff here
       }
       else if (c is TextBox && c.Name == "T")
       {
           // Do text box stuff here
       }
       if (c is Button && c.Name == "B")
       {
           // Do button stuff here
       }
    }
