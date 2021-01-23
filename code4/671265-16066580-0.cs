    Uri uri = new Uri("/OS7.xaml", UriKind.Relative);
    StreamResourceInfo info = Application.GetResourceStream(uri);
    XamlReader reader = new System.Windows.Markup.XamlReader();
    var dic = (ResourceDictionary)reader.LoadAsync(info.Stream);
    
    //then locate ResourceDictionary throgh Application.Current.Resources
    yourDictionary.MergedDictionaries.Add(dic);
