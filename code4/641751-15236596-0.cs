    public static bool HasWorkingTextProperty(Control control)
    {
        return control is Label
            || control is TextBox
            || control is ComboBox;
    }
    var controlsWithText = from c in this.Controls
                           where HasWorkingTextProperty(c)
                           select c;
    foreach(var control in controlsWithText)
    {
        string text = control.Text;
        // Do something with it.
    }
