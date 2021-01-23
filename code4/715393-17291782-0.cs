    //menu items constructor
    a.MenuItems.Add(new MenuItem("Google", new System.EventHandler(this.MenuItemClick)));
    a.MenuItems.Add(new MenuItem("Yahoo", new System.EventHandler(this.MenuItemClick)));
    
    private void MenuItemClick(Object sender, System.EventArgs e)
    {
         var m = (MenuItem)sender;
         
         if (m.Text == "Google")
         {
             Process.Start("https://www.google.com");
         }
    }
