    public ViewModelLocator()
    {
	    SimpleIoc.Default.Reset();
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
	
        SimpleIoc.Default.Register<IExampleService, ExampleServiceImplementation>();
        // Register the rest of your services
    }
