    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication4 {
        class Program {
            static void Main(string[] args) {
                Check(new Foo());
                Check(new Bar());
                Console.ReadLine();
            }
            static void Check<T>(T obj) {
                // "The type T cannot be used as type parameter..."
                if (IsDerivedOfGenericType(typeof(T), typeof(Entity<>))) {
                    System.Console.WriteLine(string.Format("{0} is Entity<T>", typeof(T)));
                }
            }
    
            static bool IsDerivedOfGenericType(Type type, Type genericType) {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                    return true;
                if (type.BaseType != null) {
                    return IsDerivedOfGenericType(type.BaseType, genericType);
                }
                return false;
            }
        }
        class Entity<T> where T : Entity<T> { }
        class Foo : Entity<Foo> { }
        class Bar { }
    }
