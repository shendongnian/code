    protected void DisplayRootViewFor(Type viewModelType, IDictionary<string, object> settings = null) 
    {
        var windowManager = IoC.Get<IWindowManager>();
        windowManager.ShowWindow(IoC.GetInstance(viewModelType, null), null, settings);
    }
