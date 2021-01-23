    private void setupTooltip(Panel panel)
    {
        var controls = panel.Children.OfType<System.Windows.Controls.TextBox>();
        foreach (var control in controls)
        {
            control.ToolTip = "Code is <" + control.Name + ">";
        }
    }
