    using System;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                ValueTypeWrapper<int> a;
                ValueTypeWrapper<int> b = new ValueTypeWrapper<int>();
                b.Value = 5;
                a = b;
                b.Value = 2;
                Console.WriteLine(Convert.ToString(a));
                Console.ReadLine();
            }
        }
        public class ValueTypeWrapper<T> where T : struct
        {
            public T Value { get; set; }
            public override string ToString()
            {
                return this.Value.ToString();
            }
        }
    }
