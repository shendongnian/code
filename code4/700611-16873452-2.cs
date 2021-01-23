    using System;
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypeWrapper<int> a;
            ValueTypeWrapper<int> b;
            // The following line creates a new instance
            // of ValueTypeWrapper<int> by the means of
            // implicit conversion (see last method defined
            // in the ValueTypeWrapper<T> class).
            b = 5;
            // Make the variable "a" point to the same
            // ValueTypeWrapper<int> instance we just created.
            a = b;
            // Now that both variables are pointing to
            // the same *instance*, change the value of
            // the Value property.
            b.Value = 2;
            // Convert.ToString(...) will call
            // ValueTypeWrapper<int>'s ToString()
            // method, which in turn produces the
            // string equivalent of the value inside
            // the Value property.
            // The Value property is equal to 2
            // on both "a" and "b" objects as they
            // point to the same instance.
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
