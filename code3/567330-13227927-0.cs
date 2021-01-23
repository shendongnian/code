    using System;
    
    public struct Foo
    {
        private int field;
        
        public int Value
        {
            get
            {
                Test.array[0].field = 10;
                return field;
            }
        }
    }    
    
    public class Test
    {
        public static Foo[] array = new Foo[1];
        
        static void Main()
        {
            Console.WriteLine(array[0].Value); // Prints 10
        }
    }
