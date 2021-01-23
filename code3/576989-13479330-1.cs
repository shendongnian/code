    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class App
    {
        public delegate object ObjectActivator(params object[] args);
        public static void Main(string[] args)
        {
            var ao = new { ID = 10000, FName = "Sample", SName = "Name" };
            var t = ao.GetType();
            var info = t.GetConstructor(new[] { typeof(int), typeof(string), typeof(string) });
            if (info == null)
            {
                throw new Exception("Info is null");
            }
            // This uses System.Linq.Expressions to create the delegate
            var activator = GetActivator(info);
            var newObj1 = activator(4, "Foo", "Bar");
            // This invokes the ConstructorInfo directly
            var newObj2 = info.Invoke(new object[] { 4, "Foo", "Bar" });
            // This uses System.Activator to dynamically create the instance
            var newObj3 = Activator.CreateInstance(t, 4, "Foo", "Bar");
        }
        
        // This uses System.Linq.Expressions to generate a delegate
        public static ObjectActivator GetActivator(ConstructorInfo ctor)
        {
            var args = Expression.Parameter(typeof(object[]), "args");
            var parameters = ctor.GetParameters().Select((parameter, index) => Expression.Convert(Expression.ArrayIndex(args, Expression.Constant(index)), parameter.ParameterType));
            return Expression.Lambda<ObjectActivator>(Expression.New(ctor, parameters), args).Compile();
        }
    }
