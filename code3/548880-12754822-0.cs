    foreach (var button in ApplicationBar.Buttons)
    {
        ((ApplicationBarIconButton) button).IsEnabled = false; // disables the button
    }
    ApplicationBar.IsMenuEnabled = false; // this will prevent menu from opening
