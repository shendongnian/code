    var oldProvider = FilterProviders.Providers.Single(
             f => f is FilterAttributeFilterProvider
        );
    FilterProviders.Providers.Remove(oldProvider);
    FilterProviders.Providers.Add(new InjectibleFilterProvider(this.Container));
