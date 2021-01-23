    private void setupTooltip(Panel obj)
    {
        var controls = obj.Children.OfType<System.Windows.Controls.TextBox>();
        foreach (var control in controls)
        {
            control.ToolTip = "Code is <" + control.Name + ">";
        }
    }
