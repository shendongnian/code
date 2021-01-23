    public static bool IsObjectEmpty(TextBox ctrlThis)
    {
        if (ctrlThis.Text == "" || ctrlThis.Text == null) {
            return false;
        }
        etc etc...
    }            
            
    public static bool IsObjectEmpty(ComboBox ctrlThis)
    {
        if (ctrlThis.SelectedValue == -1) {
            return false;
        }
        etc etc...
    }            
            
    public static bool IsObjectEmpty(NumericUpDown ctrlThis)
    {
        if (ctrlThis.Value == 0) {
            return false;
        }
        etc etc...
    }
