    public Type GetBoundToType(IKernel kernel, Type boundType)
    {
        var binding = kernel.GetBindings(boundType).FirstOrDefault();
        if (binding != null)
        {
            if (binding.Target != BindingTarget.Type && binding.Target != BindingTarget.Self)
            {
                // TODO: maybe the code  below could work for other BindingTarget values, too, feelfree to try
                throw new InvalidOperationException(string.Format("Cannot find the type to which {0} is bound to, because it is bound using a method, provider or constant ", boundType));
            }
            var req = kernel.CreateRequest(boundType, metadata => true, new IParameter[0], true, false);
            var cache = kernel.Components.Get<ICache>();
            var planner = kernel.Components.Get<IPlanner>();
            var pipeline = kernel.Components.Get<IPipeline>();
            var provider = binding.GetProvider(new Context(kernel, req, binding, cache, planner, pipeline));
            return provider.Type;
        }
        if (boundType.IsClass && !boundType.IsAbstract)
        {
            return boundType;
        }
        throw new InvalidOperationException(string.Format("Cannot find the type to which {0} is bound to", boundType));
    }
