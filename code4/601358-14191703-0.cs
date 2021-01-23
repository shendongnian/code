    public static bool IsObjectEmpty(TextBox ctrlThis)
    {
        TextBox txtThis = (TextBox)ctrlThis;
        if (txtThis.Text == "" || txtThis.Text == null)
        { return false; }
            etc etc...
    }            
            
    public static bool IsObjectEmpty(ComboBox ctrlThis)
    {
        ComboBox cboThis = (ComboBox)ctrlThis;
        if (cboThis.SelectedValue == -1)
        { return false; }
            etc etc...
    }            
            
    public static bool IsObjectEmpty(NumericUpDown ctrlThis)
    {
        NumericUpDown numThis = (NumericUpDown)ctrlThis;
        if (numThis.Value == 0)
        { return false; }
            etc etc...
    }
