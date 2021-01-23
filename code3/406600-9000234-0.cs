    public static void translate()
    {
        // get all public static props
        var properties = typeof(GuiCommands).GetProperties(BindingFlags.Public | BindingFlags.Static);
        // get their uicommands
        var routedUICommands = properties.Select(prop => prop.GetValue(null, null)).OfType<RoutedUICommand>(); // instance = null for static (non-instance) props
        foreach (RoutedUICommand ruic in routedUICommands)
            ruic.Text = DictTable.getInst().getText(ruic.Text);
    }
