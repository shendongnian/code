    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace DynamicSort
    {
        class DynamicProperty<T>
        {
            PropertyInfo SortableProperty;
    
            public DynamicProperty(string propName)
            {
                SortableProperty = typeof(T).GetProperty(propName);
            }
    
            public IComparable GetPropertyValue(T obj)
            {
                return (IComparable)SortableProperty.GetValue(obj);
            }
        }
    
        class Program
        {
            class SomeData
            {
                public int X { get; set; }
                public string Name { get; set; }
            }
    
            static void Main(string[] args)
            {
                SomeData[] data = new SomeData[]
                {
                    new SomeData { Name = "ZZZZ", X = -1 },
                    new SomeData { Name = "AAAA", X = 5 },
                    new SomeData { Name = "BBBB", X = 5 },
                    new SomeData { Name = "CCCC", X = 5 }
                };
    
    
                var prop1 = new DynamicProperty<SomeData>("X");
                var prop2 = new DynamicProperty<SomeData>("Name");
    
                var sorted = data.OrderBy(x=> prop1.GetPropertyValue(x))
                                 .ThenByDescending( x => prop2.GetPropertyValue(x));
    
                foreach(var res in sorted)
                {
                    Console.WriteLine("{0} X: {1}", res.Name, res.X);
                }
    
            }
        }
    }
