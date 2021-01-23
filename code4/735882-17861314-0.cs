    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    namespace SimpleCloneDemo
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var person = new Person { Id = 1, FirstName = "John", Surname = "Doe" };
                var clone = person.Clone();
                clone.Id = 5;
                clone.FirstName = "Jane";
                Console.WriteLine(@"person: {0}", person);
                Console.WriteLine(@"clone: {0}", clone);
                if (Debugger.IsAttached)
                    Console.ReadLine();
            }
        }
        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public override string ToString()
            {
                return string.Format("Id: {0}, Full Name: {1}, {2}", Id, Surname, FirstName);
            }
        }
        public static class ObjectExtensions
        {
            public static T Clone<T>(this T entity) where T : class
            {
                var clone = Activator.CreateInstance(entity.GetType());
                var entityPropValueDictionary = entity.AsPropValueDictionary();
                foreach (var prop in clone.GetType().GetProperties())
                {
                    clone.GetType().GetProperty(prop.Name).SetValue(clone, entityPropValueDictionary[prop.Name]);
                }
                return clone as T;
            }
            public static IDictionary<string, object> AsPropValueDictionary<T>(this T instance, params BindingFlags[] bindingFlags)
            {
                var runtimeBindingFlags = BindingFlags.Default;
                switch (bindingFlags.Count())
                {
                    case 0:
                        runtimeBindingFlags = BindingFlags.Default;
                        break;
                    case 1:
                        runtimeBindingFlags = bindingFlags[0];
                        break;
                    default:
                        runtimeBindingFlags = bindingFlags.Aggregate(runtimeBindingFlags, (current, bindingFlag) => current | bindingFlag);
                        break;
                }
                return runtimeBindingFlags == BindingFlags.Default
                    ? instance.GetType().GetProperties().ToDictionary(prop => prop.Name, prop => prop.GetValue(instance))
                    : instance.GetType().GetProperties(runtimeBindingFlags).ToDictionary(prop => prop.Name, prop => prop.GetValue(instance));
            }
        }
    }
