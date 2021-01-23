    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autofac;
    namespace ConsoleApplication1
    {
        public interface IOpenGeneric<T, U>
        {
            U Get(T value);
        }
        [AttributeUsage(AttributeTargets.Class)]
        public class DecorateAttribute : Attribute
        {
        }
        [Decorate]
        public class BooleanToStringOne : IOpenGeneric<bool, string>
        {
            public string Get(bool value)
            {
                return $"{value.ToString()} from BooleanToStringOne";
            }
        }
        [Decorate]
        public class BooleanToStringTwo : IOpenGeneric<bool, string>
        {
            public string Get(bool value)
            {
                return $"{value.ToString()} from BooleanToStringTwo";
            }
        }
        public class BooleanToStringThree : IOpenGeneric<bool, string>
        {
            public string Get(bool value)
            {
                return $"{value.ToString()} from BooleanToStringThree";
            }
        }
        public class OpenGenericDecorator<T, U> : IOpenGeneric<T, U>
        {
            private readonly IOpenGeneric<T, U> _inner;
            public OpenGenericDecorator(IOpenGeneric<T, U> inner)
            {
                _inner = inner;
            }
            public U Get(T value)
            {
                Console.WriteLine($"{_inner.GetType().Name} is being decorated!");
                return _inner.Get(value);
            }
        }
        public static class ReflectionExtensions
        {
            public static bool HasAttribute<TAttribute>(this Type type)
                where TAttribute : Attribute
            {
                return type
                    .GetCustomAttributes(typeof(TAttribute), false)
                    .Cast<Attribute>()
                    .Any();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var assembly = typeof(Program).Assembly;
                var builder = new ContainerBuilder();
                // associate types that have the [Decorate] attribute with a specific key
                builder
                    .RegisterAssemblyTypes(assembly)
                    .Where(x => x.HasAttribute<DecorateAttribute>())
                    .AsClosedTypesOf(typeof(IOpenGeneric<,>), "decoratable-service");
                // get the keyed types and register the decorator
                builder.RegisterGenericDecorator(
                    typeof(OpenGenericDecorator<,>),
                    typeof(IOpenGeneric<,>),
                    "decoratable-service");
                // no key for the ones with no [Decorate] attribute so they'll
                // get resolved "as is"
                builder
                    .RegisterAssemblyTypes(assembly)
                    .Where(x => !x.HasAttribute<DecorateAttribute>())
                    .AsClosedTypesOf(typeof(IOpenGeneric<,>));
                var container = builder.Build();
                var booleanToStrings = container.Resolve<IEnumerable<IOpenGeneric<bool,string>>>();
                foreach (var item in booleanToStrings)
                {
                    Console.WriteLine(item.Get(true));
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
