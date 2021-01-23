    public bool IsInEditMode()
    {
        const int menuItemType = 1;
        const int newMenuId = 18;
        CommandBarControl newMenu =
            Application.CommandBars["Worksheet Menu Bar"].FindControl(menuItemType, newMenuId, Type.Missing, Type.Missing, true);
        return newMenu != null && !newMenu.Enabled;
    }
