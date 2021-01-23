    using System;
    
    public class EnumPlus
    {
        public enum Constant
        {
            FIRST,
            SECOND
        };
    
        // if this implicit cast is removed the result is what I expected
        public static implicit operator int(EnumPlus f)
        {
            return 1;
        }
    
        public static string operator+(EnumPlus o, int i)
        {
            Console.WriteLine("operator + called for int");
            return "BAD";
        }
    
        public static string operator+(EnumPlus o, Constant Constant)
        {
            Console.WriteLine("operator + called for enum");
            return "OK";
        }
    
        public static void Main()
        {
            EnumPlus o = new EnumPlus();
            Console.WriteLine(o + Constant.FIRST);
        }
    
    }
