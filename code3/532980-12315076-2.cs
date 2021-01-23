    //MethodName<T,U>(T para1, U para2)
    using System;
    using System.Collections.Generic;
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
                foreach (var x in sample.FindAll(item => predicate(JustValue<double>(item))))
                {
                    x.value = i;
                }
                return true;
            }
    
            public T JustValue<T>(Mycapsule<int, T> i)
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
