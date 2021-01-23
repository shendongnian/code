    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using SimpleInjector;
    using SimpleInjector.Advanced;
    using SimpleInjector.Extensions;
    public static class OpenGenericConstructorExtensions
    {
        public static void EnableOpenGenericConstructorSelection(
            this ContainerOptions options)
        {
            var selectors = new List<Func<Type, ConstructorInfo>>();
            options.ConstructorResolutionBehavior = 
                new ConstructorResolutionBehavior(
                    options.ConstructorResolutionBehavior, selectors);
            options.Container.SetItem("selectors", selectors);
        }
        public static void RegisterOpenGeneric(this Container container, 
            Type openGenericServiceType,
            Type openGenericImplementation, 
            Expression<Func<object>> constructorSelector)
        {
            var selectors = (List<Func<Type, ConstructorInfo>>)
                container.GetItem("selectors");
            if (selectors == null) throw new InvalidOperationException(
                "call Options.EnableOpenGenericConstructorSelection first.");
            var constructor = 
                ((NewExpression)constructorSelector.Body).Constructor;
            selectors.Add(type =>
            {
                if (type == openGenericImplementation || (type.IsGenericType && 
                    type.GetGenericTypeDefinition() == openGenericImplementation))
                {
                    return GetConstructorForType(type, constructor);
                }
                return null;
            });
            container.RegisterOpenGeneric(openGenericServiceType, 
                openGenericImplementation);
        }
        private static ConstructorInfo GetConstructorForType(
            Type closedImplementationType, 
            ConstructorInfo closedConstructor)
        {
            var parameters = closedConstructor.GetParameters();
            var constructors =
                from ctor in closedImplementationType.GetConstructors()
                where ctor.GetParameters().Length == parameters.Length
                let parameterPairs = ctor.GetParameters().Zip(parameters, (p1, p2) =>
                    new { left = p1.ParameterType, right = p2.ParameterType })
                where parameterPairs.All(pair => pair.left == pair.right ||
                        (pair.left.IsGenericType && pair.right.IsGenericType &&
                        pair.left.GetGenericTypeDefinition() == pair.right.GetGenericTypeDefinition()))
                select ctor;
            return constructors.Single();
        }
        private sealed class ConstructorResolutionBehavior 
            : IConstructorResolutionBehavior
        {
            private readonly IConstructorResolutionBehavior original;
            private readonly List<Func<Type, ConstructorInfo>> constructorSelectors;
            public ConstructorResolutionBehavior(
                IConstructorResolutionBehavior original,
                List<Func<Type, ConstructorInfo>> constructorSelectors)
            {
                this.original = original;
                this.constructorSelectors = constructorSelectors;
            }
            public ConstructorInfo GetConstructor(Type serviceType, 
                Type implementationType)
            {
                var constructors =
                    from selector in this.constructorSelectors
                    let constructor = selector(implementationType)
                    where constructor != null
                    select constructor;
                return constructors.FirstOrDefault() ?? 
                    this.original.GetConstructor(serviceType, 
                        implementationType);
            }
        }
    }
