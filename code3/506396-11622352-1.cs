    public ChildControllerFactory(IEnumerable<IChildController> childControllers)
    {
        var childControllerDictionary = new Dictionary<string, IChildController>();
        _childControllerDictionary = childControllerDictionary;
        for(IChildController i in _childControllerDictionary) i.setChildControllerFactory(this);
    }
