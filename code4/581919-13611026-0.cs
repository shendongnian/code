    using System;
    using System.Collections.Generic;
    
    struct MutableStruct
    {
        public int Value { get; set; }
        
        public void AssignValue(int newValue)
        {
            Value = newValue;
        }
    }
    
    class Test
    {
        static void Main()
        {
            var list = new List<MutableStruct>()
            {
                new MutableStruct { Value = 10 }
            };
            
            Console.WriteLine("With loop variable capture");
            foreach (MutableStruct item in list)
            {
                Console.WriteLine("Before: {0}", item.Value);
                item.AssignValue(30);
                Console.WriteLine("After: {0}", item.Value);
            }
            // Reset...
            list[0] = new MutableStruct { Value = 10 };
    
            Console.WriteLine("With loop variable capture");
            foreach (MutableStruct item in list)
            {
                Action capture = () => Console.WriteLine(item.Value);
                Console.WriteLine("Before: {0}", item.Value);
                item.AssignValue(30);
                Console.WriteLine("After: {0}", item.Value);
            }
        }
    }
