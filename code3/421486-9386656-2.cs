    public static class RegistrationExtensions
    {
        /// <summary>
        /// Injects dependencies into the instance's properties and fields.
        /// </summary>
        /// <param name="context">
        /// The component context.
        /// </param>
        /// <param name="instance">
        /// The instance into which to inject dependencies.
        /// </param>
        public static void InjectDependencies(this IComponentContext context, object instance)
        {
            Enforce.ArgumentNotNull(context, "context");
            Enforce.ArgumentNotNull(instance, "instance");
            var injector = new AttributedDependencyInjector(context);
            injector.InjectDependencies(instance);
        }
    }
