    // In WPF:
    var isDesign = DesignerProperties.GetIsInDesignMode(Application.Current.MainWindow);
    // In Silverlight:
    var isDesign = DesignerProperties.GetIsInDesignMode(Application.Current.RootVisual);
    if(isDesign)
    {
        // designer code
        return;
    }
    // non designer code
