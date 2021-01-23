    public IHub Create(HubDescriptor descriptor)
    {
        if (HttpContext.Current == null)
            _container.BeginLifetimeScope();
        return _container.GetInstance(descriptor.HubType) as IHub;
    }
