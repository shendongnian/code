    public virtual void Initialize()
    {  
        RegisterView<IView, AnyView>("AnyView");
        Register<IAvailableView>(new AvailableView("AnyView", "MyModuleName"));
    }
