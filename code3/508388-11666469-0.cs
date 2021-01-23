     protected void Page_Load(object sender, EventArgs e)
    {
        GridFilterMenu menu = RadGrid1.FilterMenu;
        foreach (RadMenuItem item in menu.Items)
        {   
            if (item.Text == "StartsWith")
            {
                item.Text = "Your new text";
            }
        }
    }
