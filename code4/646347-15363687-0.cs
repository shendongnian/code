    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace ConsoleApplication21
    {
        class Program
        {
            static void Main(string[] args)
            {
                class1 c1 = new class1();
                FieldInfo[] fields = c1.GetType().GetFields(
                             BindingFlags.NonPublic |
                             BindingFlags.Instance);
                Console.WriteLine("class1");
                foreach (FieldInfo fi in fields)
                {
                    Console.WriteLine(fi.Name);
                }
    
                class2 c2 = new class2();
                fields = c2.GetType().GetFields(
                             BindingFlags.NonPublic |
                             BindingFlags.Instance);
    
                Console.WriteLine("class2");
                foreach (FieldInfo fi in fields)
                {
                    Console.WriteLine(fi.Name);
                }
    
                Console.ReadKey();
            }
        }
    
        public class class1
        {
            private string field1;
            private string field2;
    
            private void a(string hello)
            {
    
            }
        }
    
        public class class2
        {
            private string field3;
            private string field4;
    
            private void a(string hello)
            {
    
            }
        }
    }
