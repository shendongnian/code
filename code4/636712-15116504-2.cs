    using System;
    
    public class Int32Wrapper
    {
        private readonly int value;
        public int Value { get { return value; } }
        
        public Int32Wrapper(int value)
        {
            this.value = value;
        }
        
        public static Int32Wrapper operator +(Int32Wrapper lhs, Int32Wrapper rhs)
        {
            Console.WriteLine("In the operator");
            return new Int32Wrapper(lhs.value + rhs.value);
        }
    }
    
    class Test
    {
        static void Main()
        {
            Int32Wrapper x = new Int32Wrapper(10);
            Int32Wrapper y = new Int32Wrapper(5);
            Int32Wrapper z = x + y;
            Console.WriteLine(z.Value); // 15
        }
    }
