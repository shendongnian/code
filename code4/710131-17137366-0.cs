    // Inside the Button click event of TutorialPage.xaml
    // Change the mapping so that MainPage points to itself
    ((UriMapper)App.RootFrame.UriMapper).UriMappings[0].MappedUri = 
        new Uri("/MainPage.xaml", UriKind.Relative);
    // Since RootFrame.CurrentSource is still set to MainPage, you need to pass
    // some dummy query string to force the navigation
    App.RootFrame.Navigate(new Uri("/MainPage.xaml?dummy=1", UriKind.Relative));
    // Remove back entry so that if user taps the back button 
    // you won't get back to tutorial
    App.RootFrame.RemoveBackEntry();
