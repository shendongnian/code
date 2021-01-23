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
                new ResolveIt().InvokeIt(LocationType.State, 1, 5);
                Console.ReadLine();
            }
        }
    
        public class ResolveIt
        {
            private static readonly Action<int, int>[] Actions
                = Enum.GetValues(typeof (LocationType))
                      .Cast<LocationType>()
                      .Select(v => typeof (ResolveIt)
                      .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                      .First(n => n.Name == "SomeMethod")
                      .GetGenericMethodDefinition()
                      .MakeGenericMethod(new[] { Type.GetType(typeof(ResolveIt).Namespace + ".Data" + Enum.GetName(typeof(LocationType), v)) }))
                      .Select(mi => new Action<int, int>((i, v) => mi.Invoke(null, BindingFlags.NonPublic, null, new object[] { i, v }, CultureInfo.CurrentCulture)))
                      .ToArray();
            
            public void InvokeIt(LocationType type, int x, int y)
            {
                Actions[(int)type](x, y);
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
