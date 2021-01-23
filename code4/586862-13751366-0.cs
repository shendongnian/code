    private void LoadStyles(StyleType styleType)
    {
        ResourceDictionary merged = new ResourceDictionary();
        ResourceDictionary generic = new ResourceDictionary();
        ResourceDictionary theme = new ResourceDictionary();
        generic.Source = new Uri("ms-appx:/Common/StandardStyles.xaml");
        switch (styleType)
            {
                default:
                case StyleType.Custom1: { theme.Source = new Uri("ms-appx:/Common/AppStyles-Custom1.xaml"); break; }
                case StyleType.Custom2: { theme.Source = new Uri("ms-appx:/Common/AppStyles-Custom2.xaml"); break; }
                case StyleType.Custom3: { theme.Source = new Uri("ms-appx:/Common/AppStyles-Custom3.xaml"); break; }
            }
        merged.MergedDictionaries.Add(generic);
        merged.MergedDictionaries.Add(theme);
        App.Current.Resources = merged;
        //this.ApplyTemplate(); <- doesn't seem to reapply resources to layout tree
    }
