    MessageDialog dialog = new MessageDialog(string.Empty, "Are you sure you wish to delete this record?");
    dialog.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
    dialog.Commands.Add(new UICommand { Label = "No", Id = 0 });
    
    IUICommand command = await dialog.ShowAsync();
