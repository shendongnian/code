    private void TraverseMenu(Menu menu)
    {
        Output(string.Format("Now reading menu #{0}, named {1}", menu.MenuID, menu.Name));
        if (menu._ChildMenus != null)
        {
            foreach (Menu child in menu._ChildMenus)
            {
                TraverseMenu(child);
            }
        }
    }
