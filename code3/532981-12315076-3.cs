    using System;
    using System.Collections.Generic;
    using System.Reflection;
    namespace test
    {
        class MainClass
        {
            public static List<Mycapsule<int, double>> sample = new List<Mycapsule<int, double>>();
    
            public static void Main(string[] args)
            {
    
                sample.Add(new Mycapsule<int, double> { id = 1, value = 1.2 });
                update(pred, 12.3);
            }
    
            public static bool pred(double x)
            {
                if (x == 2.5) return true;
                return false;
            }
    
            public static bool update<T>(Func<T, bool> predicate, T i)
            {
                var myCollection = sample.FindAll(p => pred(JustValue<double>(p)));
                MainClass mainClass = new MainClass();
                foreach (var x in myCollection)
                {
                    MethodInfo changeTypeMethod = typeof(MainClass).GetMethod("GetValue");
                    object value = changeTypeMethod.Invoke(mainClass, new object[] { i, typeof(T) });
                    PropertyInfo valueProperty = x.GetType().GetProperty("value");
                    valueProperty.SetValue(x, value);
                }
                return true;
            }
    
            public T GetValue<T>(T i)
            {
                return (T)Convert.ChangeType(i, typeof(T));
            }
    
            public static T JustValue<T>(Mycapsule<int, T> i)
            {
                return i.value;
            }
        }
        //Outside the MainClass inside the same namespace 
        public class Mycapsule<KT, T>
        {
            public KT id { get; set; }
            public T value { get; set; }
            public int p; // and more   
    
        }
    }
