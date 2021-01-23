    if (!TestAppHost.Instance.Plugins.Any(x => x.GetType() == typeof(ValidationFeature)))
    {
        TestAppHost.Instance.Plugins.Add(new ValidationFeature());
    }
    
    if (!TestAppHost.Instance.RequestFilters.Any(x => x.Target.ToString() == "ServiceStack.ServiceInterface.Validation.ValidationFilters"))
    {
        TestAppHost.Instance.Container.RegisterValidators(typeof(CreateWidgetValidator).Assembly);
    }
