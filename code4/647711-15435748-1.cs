    public ViewModelLocator()
    {
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    
        SimpleIoc.Default.Register<MainViewModel>(true);
    }
