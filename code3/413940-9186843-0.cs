    public static void ToUpperCase(params TextBox[] controls)
    {
        foreach (TextBox oControl in controls)
            AddTextChangedHandler<TextBox>(oControl);
    }
    
    public static void ToUpperCase(params ComboBox[] controls)
    {
        foreach (ComboBoxControl oControl in controls)
            AddTextChangedHandler<ComboBox>(oControl);
    }
    private static void AddTextChangedHandler<TControl>(TControl oControl) {
        oControl.TextChanged += (sndr, evnt) =>
        {
            TControl txtControl = sndr as TControl;
            int pos = txtControl.SelectionStart;
            txtControl.Text = txtControl.Text.ToUpper();
            txtControl.SelectionStart = pos;
        };
    } 
