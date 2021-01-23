    public static class AutofacExtensions
    {
        public static void RegisterGenericTypesWithFactoryDecorator(
            this ContainerBuilder builder, 
            IEnumerable<Type> relevantTypes, 
            Type factoryDecorator,
            Type implementedInterfaceGenericTypeDefinition)
        {
            var serviceName = implementedInterfaceGenericTypeDefinition.ToString();
            foreach (var implementationType in relevantTypes)
            {
                var implementedInterfaces =
                    implementationType.GetGenericInterfaces(
                        implementedInterfaceGenericTypeDefinition);
                foreach (var implementedInterface in implementedInterfaces)
                    builder.RegisterType(implementationType)
                           .Named(serviceName, implementedInterface);
            }
            builder.RegisterGeneric(factoryDecorator)
                   .WithParameter(
                       (p, c) => IsSpecificFactoryParameter(p, implementedInterfaceGenericTypeDefinition), 
                       (p, c) => c.ResolveNamed(serviceName, p.ParameterType))
                   .As(implementedInterfaceGenericTypeDefinition)
                   .SingleInstance();
        }
        private static bool IsSpecificFactoryParameter(ParameterInfo p,
                                                       Type expectedFactoryResult)
        {
            var parameterType = p.ParameterType;
            if (!parameterType.IsGenericType ||
                parameterType.GetGenericTypeDefinition() != typeof(Func<>))
                return false;
            var actualFactoryResult = p.ParameterType.GetGenericArguments()
                                                     .First();
            if (actualFactoryResult == expectedFactoryResult)
                return true;
            if (expectedFactoryResult.IsGenericTypeDefinition && 
                actualFactoryResult.IsGenericType)
                return expectedFactoryResult == 
                       actualFactoryResult.GetGenericTypeDefinition();
            return false;
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetGenericInterfaces(
            this Type type, Type openGenericInterface)
        {
            return
                type.GetInterfaces()
                    .Where(x => x.IsGenericType &&
                                x.GetGenericTypeDefinition() == openGenericInterface);
        }
    }
