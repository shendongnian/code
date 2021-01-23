    void Menu_MenuItemClick(Object sender, MenuEventArgs e)
    {
    // Display the text of the menu item selected by the user.
    Message.Text = "You selected " + 
      e.Item.Text + ".";
    }
