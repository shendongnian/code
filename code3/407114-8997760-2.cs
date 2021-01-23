    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                new ResolveIt<LocationType>().InvokeIt(LocationType.State, 1, 5);
                Console.ReadLine();
            }
        }
    
        public class ResolveIt<TEnum> // Unfortunately can't constrain on enums
        {
            private static readonly Action<int, int>[] Actions
                = Enum.GetValues(typeof(TEnum))
                  .Cast<TEnum>()
                  .Select(v => typeof(ResolveIt<TEnum>)
                  .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                  .First(n => n.Name == "SomeMethod")
                  .GetGenericMethodDefinition()
                  .MakeGenericMethod(new[] { Type.GetType(typeof(ResolveIt<TEnum>).Namespace + ".Data" + Enum.GetName(typeof(TEnum), v)) }))
                  .Select(mi => (Action<int, int>)Delegate.CreateDelegate(typeof(Action<int, int>), mi))
                  .ToArray();
    
            public void InvokeIt(TEnum type, int x, int y)
            {
                Actions[(Int32)Convert.ChangeType(type, typeof(Int32))](x, y);
            }
    
            private static void SomeMethod<TLocation>(int x, int y) where TLocation : DataLocation
            {
                Console.Out.WriteLine(typeof(TLocation));
            }
        }
        public enum LocationType { Country, State, City, Zip, }
        public class DataLocation { }
        public class DataCountry:DataLocation { }
        public class DataState:DataLocation { }
        public class DataCity:DataLocation { }
        public class DataZip:DataLocation { }
    }
