    Application.Current.Resources["BackgroundColor"] = this.SelectedBackgroundColor;
    
    Application.Current.Resources.MergedDictionaries.Clear();
    var dictionary = new ResourceDictionary();
    dictionary.Source = new Uri("ControlStyles.xaml", UriKind.Relative);
    Application.Current.Resources.MergedDictionaries.Add(dictionary);
