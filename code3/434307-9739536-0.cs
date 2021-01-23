    ResourceDictionary myResourceDictionary = new ResourceDictionary();
    
    myResourceDictionary.Source = new Uri("Dictionary1.xaml", UriKind.Relative);
    Application.Current.Resources.MergedDictionaries.Add(myResourceDictionary);
    
    myResourceDictionary.Source = new Uri("Dictionary2.xaml", UriKind.Relative);
    Application.Current.Resources.MergedDictionaries.Add(myResourceDictionary);
