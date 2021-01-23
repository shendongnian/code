    if (!System.Web.HttpContext.Current.User.IsInRole("ADMIN"))
        {
            MenuItem mnuItem = NavigationMenu.FindItem("About"); // Find particular item
            if (mnuItem != null)
            {
                NavigationMenu.Items.Remove(mnuItem);
            }
        }
