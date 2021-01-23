    using System;
    class Foo<T> where T : class { }
    class Bar { }
    class Program {
        static void Main(string[] args) {
            var barType = Type.GetType("ConsoleApplication29.Bar");
            var fooType = typeof(Foo<>).MakeGenericType(barType);
            var fooCtor = fooType.GetConstructor(Type.EmptyTypes);
            var instance = fooCtor.Invoke(new object[] { });
            Console.WriteLine(instance.GetType().FullName);
            Console.ReadLine();
        }
    }
