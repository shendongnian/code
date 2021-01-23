        using Autofac;
        using Autofac.Core;
        using Autofac.Core.Activators.Reflection;
        ...
    
            private static IEnumerable<Type> GetImplementingTypes<T>(ILifetimeScope scope)
            {
                //base on http://bendetat.com/autofac-get-registration-types.html article
        
                return scope.ComponentRegistry
                    .RegistrationsFor(new TypedService(typeof(T)))
                    .Select(x => x.Activator)
                    .OfType<ReflectionActivator>()
                    .Select(x => x.LimitType);
            }
