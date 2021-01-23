         protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
            {
                
                int i = 0; // index of the menu item
       if (Int32.Parse(e.Item.Value) == 0)
                {
                    Menu1.Items[0].ImageUrl = "images/selectedt1.jpg";
                    Menu1.Items[1].ImageUrl = "images/unselectedt2.jpg";
                    Menu1.Items[2].ImageUrl = "images/unselectedt3.jpg";
                    Menu1.Items[3].ImageUrl = "images/unselectedt4.jpg";
                }
                if (Int32.Parse(e.Item.Value) == 1)
                {
                    Menu1.Items[0].ImageUrl = "images/unselectedt1.jpg";
                    Menu1.Items[1].ImageUrl = "images/selectedt2.jpg";
                    Menu1.Items[2].ImageUrl = "images/unselectedt3.jpg";
                    Menu1.Items[3].ImageUrl = "images/unselectedt4.jpg";
                }
                if (Int32.Parse(e.Item.Value) == 2)
                {
                    Menu1.Items[0].ImageUrl = "images/unselectedt1.jpg";
                    Menu1.Items[1].ImageUrl = "images/unselectedt2.jpg";
                    Menu1.Items[2].ImageUrl = "images/selectedt3.jpg";
                    Menu1.Items[3].ImageUrl = "images/unselectedt4.jpg";
                }
    }
