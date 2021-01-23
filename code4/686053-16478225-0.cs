    using System;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                new Program().Run();
            }
            void Run()
            {
                object obj = new XYZ();
                var xField = obj.GetType().GetField("x", BindingFlags.NonPublic | BindingFlags.Instance);
                int xValue = (int) xField.GetValue(obj);
                Console.WriteLine(xValue); // Prints 0
            
                xField.SetValue(obj, 42);  // Set private field value to 42
                xValue = (int)xField.GetValue(obj);
                Console.WriteLine(xValue); // Prints 42
            }
        }
        public class XYZ
        {
            int x;
            int y;
            int z;
    
            public XYZ()
            {
                x=0;
                y=1;
                z=2;
            }
        };
    }
