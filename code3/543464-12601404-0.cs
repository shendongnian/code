    foreach (Control c in formMain.Controls)
     {
        if(c.GetType()==typeof(ComboBox))
        {
            ComboBox cb = (ComboBox) c;
            //do something
        }
        else if(c.GetType()==typeof(TextBox))
        {
            TextBox t = (TextBox) c;
            t.ReadOnly = true;
        }
     }
