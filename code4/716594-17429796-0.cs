    protected void MainMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        /*your necessary code*/
        Response.Redirect(((Menu)sender).SelectedItem.Target);
    }
