    private void TraverseMenu(Menu menu, int level)
    {
        Output(string.Format("Now reading menu #{0}, named {1} in level {2}", menu.MenuID, menu.Name, level));
        if (menu._ChildMenus != null)
        {
            foreach (Menu child in menu._ChildMenus)
            {
                TraverseMenu(child, level + 1);
            }
        }
    }
    
    private void TraverseMenu(Menu menu)
    {
        TraverseMenu(menu, 0);
    }
