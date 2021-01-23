    public static bool IsInDesignMode
    {
        get
        {
            #if Silverlight
                return !HtmlPage.IsEnabled;;
            #else
                return DesignerProperties.GetIsInDesignMode(new DependencyObject());
            #endif
        }
    }
