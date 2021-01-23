    foreach (Control control in Controls) {
        TextBox txt = control as TextBox;
        if (txt!=null) {
            txt.Text = "bla";
            ...
        }
        ComboBox cbo = control as ComboBox;
        if (cbo!=null) {
            cbo.SelectedItem = ...
            ...
        }
       
        ...
    }
