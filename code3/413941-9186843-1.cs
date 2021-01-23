    public static void ToUpperCase(params TextBox[] controls)
    {
        foreach (TextBox oControl in controls)
            oControl.TextChanged += (sndr, evnt) =>
            {
                TextBox txtControl = sndr as TextBox ;
                int pos = txtControl.SelectionStart;
                txtControl.Text = txtControl.Text.ToUpper();
                txtControl.SelectionStart = pos;
            };
    }
    
    public static void ToUpperCase(params ComboBox[] controls)
    {
        foreach (ComboBoxControl oControl in controls)
            oControl.TextChanged += (sndr, evnt) =>
            {
                ComboBox txtControl = sndr as ComboBox;
                int pos = txtControl.SelectionStart;
                txtControl.Text = txtControl.Text.ToUpper();
                txtControl.SelectionStart = pos;
            };
    }
