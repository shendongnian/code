            if (UserType == "Power-User")
                {
                    Menu1.Items.Find("MenuToDelete1", true)[0].Enabled = false;
                    Menu1.Items.Find("MenuToDelete2", true)[0].Enabled = false;
    
                    //or
    
                    Menu1.Items.Remove(Menu1.FindItem("MenuToDelete"));
                    Menu1.Items.Remove(Menu1.FindItem("MenuToDelete2"));
                }
                if (UserType == "BT_User")
                {
                    Menu1.Items.Find("DeletedItem1", true)[0].Enabled = true;
                    Menu1.Items.Find("DeletedItem2", true)[0].Enabled = true;
    
                    MenuItem item1 = new MenuItem();
                    item.Text = "DeletedItem1";
                    MenuItem item2 = new MenuItem();
                    item.Text = "DeletedItem2";
                    
                    //or
                    menuStrip1.Items.Insert(index1, item1);
                    menuStrip1.Items.Insert(index2, item2);
                }
