    protected void rtlMyToolBar_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            var toolBarButton = e.Item as RadToolBarButton;
            string commandName = toolBarButton.CommandName;
            if (commandName == "YourCommandName")
            {
                //Your logic
            }
        }
