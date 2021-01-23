    private object DefaultValue(IServiceProvider serviceProvider)
    {
        if (Binding.FallbackValue != null)
            return Binding.FallbackValue;
        var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
        if (provideValueTarget == null)
        {
            throw new ArgumentException("provideValueTarget == null");
        }
        var dependencyProperty = (DependencyProperty)provideValueTarget.TargetProperty;
        return dependencyProperty.DefaultMetadata.DefaultValue;
    }
