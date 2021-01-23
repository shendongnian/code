    static ViewModelLocator()
    {
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        SimpleIoc.Default.Register<ViewModel1>();
        SimpleIoc.Default.Register<ViewModel2>();
        SimpleIoc.Default.Register<ViewModel3>();
    }
    
    public ViewModel1 ViewModel1
    {
        get
        {
            return ServiceLocator.Current.GetInstance<ViewModel1>();
        }
    }
    
    public ViewModel2 ViewModel2
    {
        get
        {
            return ServiceLocator.Current.GetInstance<ViewModel2>();
        }
    }
    
    public ViewModel3 ViewModel3
    {
        get
        {
            return ServiceLocator.Current.GetInstance<ViewModel3>();
        }
    }
