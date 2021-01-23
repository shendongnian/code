    public static string GetMenuByType(this string[] menu, MenuType type)
    {
        int index = (int)type;
        if (menu.Length > index)
            return menu[index];
        else
            return null;
    }
