     protected void menuTabs_MenuItemClick(object sender, MenuEventArgs e)
            {
                multiTabs.ActiveViewIndex = Int32.Parse(menuTabs.SelectedValue);
                if (menuTabs.Items[0].Selected == true)
                {
    
                    menuTabs.Items[0].ImageUrl = "~/Images/widget1_over.png";
                    menuTabs.Items[1].ImageUrl = "~/Images/widget2.png";
                }
    
                if (menuTabs.Items[1].Selected == true)
                {
                    menuTabs.Items[1].ImageUrl = "~/Images/widget2_over.png";
                    menuTabs.Items[0].ImageUrl = "~/Images/widget1.png";
    
                }
            }
