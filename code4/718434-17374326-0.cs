    public ActivatorWrapper
    {
        public virtual object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
