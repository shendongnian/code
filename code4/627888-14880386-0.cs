    foreach (Control c in this.Controls)
    {
       if (c is TextBox)
       {
            ((TextBox)c).Text = "";
       }
       else if (c is ComboBox)
       {
            ((ComboBox)c).SelectedIndex = 0;
       }
       else if (c is NumericUpDown)
       {
            ((NumericUpDown)c).Value= 0;
       }
    }
