    public class SpecialConstructorResolutionBehavior
        : IConstructorResolutionBehavior
    {
        private IConstructorResolutionBehavior original;
        public SpecialConstructorResolutionBehavior(
            IConstructorResolutionBehavior original)
        {
            this.original = original;
        }
        public ConstructorInfo GetConstructor(Type serviceType, 
            Type implementationType)
        {
            if (serviceType.IsGenericType &&
                serviceType.GetGenericTypeDefinition() == typeof(IOpenType<>))
            {
                // do alternative constructor selection here for open types.
                // For instance:
                return (
                    from ctor in implementationType.GetConstructors()
                    orderby ctor.GetParameters().Length descending
                    select ctor)
                   .First();
            }
            // fall back to default behavior
            return original.GetConstructor(serviceType, implementationType);
        }
    }
