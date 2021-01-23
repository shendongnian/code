    using System;
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypeWrapper<int> a;
            ValueTypeWrapper<int> b;
            b = 5;
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
        public static implicit operator ValueTypeWrapper<T>(T value)
        {
            return new ValueTypeWrapper<T> { Value = value };
        }
    }
