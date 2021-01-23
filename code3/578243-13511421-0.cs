    protected void Button_Clicked(Object sender, EventArgs e)
    {
        Button thisButton = (Button) sender;
        thisButton.Text = "Currently Viewing";
        RepeaterItem item = (RepeaterItem) thisButton.NamingContainer;
        IEnumerable<Button> buttons = item.Controls.OfType<Button>();
        foreach(var btn in buttons)
        {
            btn.Enabled = btn != thisButton;
        }
    }
