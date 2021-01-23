    public ViewModelLocator()
    {
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        SimpleIoc.Default.Register<FilterViewModel>();
        ServiceLocator.Current.GetInstance<FilterViewModel>();
    }
