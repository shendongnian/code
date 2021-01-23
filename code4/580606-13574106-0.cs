    foreach (Control control in Form.Controls)
    {
        if (control is GroupBox)
        {
             GroupBox gb = (GroupBox)control;
             foreach (Control control in gb.Controls)
             {
                 if (control is RadioButton)
                 {
                    rb = (RadioButton)control;
                    //rb will allow you to access all of the RadioButton's properties and act accordingly.
                 }
             }
        }
    }
