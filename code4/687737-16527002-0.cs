    using System;
    class Test
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
    }
    class MainClass
    {
        static T MapArray<T>(double[] array, string propertyStartWith) where T: new()
        {
            T obj = new T();
            Type t = typeof(T);
            for (int i = 0; i < array.Length; i++)
            {
                var property = t.GetProperty(propertyStartWith + (i + 1).ToString());
                property.SetValue(obj, Convert.ChangeType(array[i], property.PropertyType), null);
            }
            return obj;
        }
        public static void Main (string[] args)
        {
            double[] d = new double[] {
                Math.PI, Math.E
            };
            Test t = MapArray<Test> (d, "P");
            Console.WriteLine (t.P1);
            Console.WriteLine (t.P2);
        }
    }
