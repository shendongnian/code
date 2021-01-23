    public static class MenuFunctions
    {
        public static bool ShowMenu(MenuType menuType)
        {
            bool showMenu = false;
            string appSetting = ConfigurationManager.AppSettings["YourKey"];
            if (!String.IsNullOrEmpty(appSetting))
                showMenu = appSetting.Contains("/" + (int)menuType.ToString() + "/");
            return showMenu;
        }
    }
