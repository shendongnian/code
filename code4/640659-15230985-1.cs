    ResourceDictionary styleDictionary = new ResourceDictionary()
    {
        Source = new Uri("/Project;component/Styles.xaml", UriKind.Absolute)
    };
    ResourceDictionary colorDictionary = new ResourceDictionary()
    {
        Source = new Uri("/Project;component/Colors.xaml", UriKind.Absolute)
    };
    styleDictionary.MergedDictionaries.Add(colorDictionary);
    Application.Current.Resources.MergedDictionaries.Add(styleDictionary);
