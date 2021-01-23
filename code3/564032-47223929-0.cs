        menu.VisibleChanged += (s, e) =>
        {
            if (menu.Visible)
            {
                MouseWheel += ScrollMenu;
                menu.MouseWheel += ScrollMenu;
            }
            else
            {
                MouseWheel -= ScrollMenu;
                menu.MouseWheel -= ScrollMenu;
            }
        };
