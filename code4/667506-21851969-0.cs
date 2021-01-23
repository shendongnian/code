    private async void ListBoxItem_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        PopupMenu menu = new PopupMenu();
        string[] items = ((ListBoxItem)sender).Tag.ToString().Split(',');
        foreach (string item in items)
        {
            menu.Commands.Add(new UICommand(item, (command) =>
            {
                // do stuff
            }));
        }
        var chosenCommand = await menu.ShowAsync(e.GetPosition(this));
        // do something with chosen command value
    }
