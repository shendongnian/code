    if (!TestAppHost.Instance.Plugins.Any(x => x.GetType() == typeof(ValidationFeature)))
    {
        Console.Write("Validation Plugin is not added");
        //TestAppHost.Instance.Plugins.Add(new ValidationFeature());
    }
    
    if (!TestAppHost.Instance.RequestFilters.Any(x => x.Target.ToString() == "ServiceStack.ServiceInterface.Validation.ValidationFilters"))
    {
        Console.Write("No validation request filter");
       //TestAppHost.Instance.Container.RegisterValidators(typeof(CreateWidgetValidator).Assembly);
    }
