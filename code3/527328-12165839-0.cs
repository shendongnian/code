    public MyBootstrapper()
    {
        ConventionManager
            .AddElementConvention<Label>(Label.ContentProperty, 
                                        "Content", 
                                        "DataContextChanged");  
    }
