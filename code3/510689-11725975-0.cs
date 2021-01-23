    using System;
    using System.Reflection;
    
    namespace ReflectionProp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo obj = new Foo { Name = "obj", Num = null, Price = null };
                Console.WriteLine(obj);
    
                SetAllNonNullableProperties(obj, 100, 20);
                
                Console.WriteLine(obj);
    
                Console.ReadKey();
            }
    
            private static void SetAllNonNullableProperties(Foo obj, int num, decimal dec)
            {
                Type t = obj.GetType();
                PropertyInfo[] props = t.GetProperties();
    
                foreach (var prop in props)
                {
                    if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                    {
                        if (prop.GetValue(obj, null) == null)
                        {
                            if(prop.PropertyType == typeof(Nullable<int>))
                                prop.SetValue(obj, num, null);
    
                            if (prop.PropertyType == typeof(Nullable<decimal>))
                                prop.SetValue(obj, dec, null);
                        }                    
                    }
                }
            }
        }
    
        public class Foo
        {
            public Nullable<int> Num {get;set;}
            public string Name { get; set; }
            public Nullable<decimal> Price { get; set; }
    
            public override string ToString()
            {
                return String.Format("Name: {0}, num: {1}, price: {2}", Name, Num, Price);
            }
        }
    }
