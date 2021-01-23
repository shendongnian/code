           if(UserType == "Power-User")
            {
            MenuItem mnuItem = Menu1.FindItem("MenuOption"); // If delete a specific item
            
             //to remove
             Menu1.Items.Remove(mnuItem);
             //to disable and not remove 
             mnuItem.Enabled = false;
            }
            if (UserType == "BT_User")
          { 
           Your other logic
          }
