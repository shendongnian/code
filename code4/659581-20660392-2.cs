    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    if (!settings.Contains("note"))
    {
         settings.Add("note", "$#$#$#%#%#????===&&&&&some note Text!#@#@@@  someText @$$@%@%@%@^@@&^*@&(*(**)*)_((_(_(_*(&*(^*&%&%*)");
    }
    settings.Save();
    NavigationService.Navigate(new Uri(@"/Pages/EditNote.xaml", UriKind.Relative));
