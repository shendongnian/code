    using System;
    using System.Reflection;
    
    public struct MutableStruct
    {
        public int x;
    }
    
    class Test
    {
        public static void ChangeByRef(ref MutableStruct foo)
        {
            foo = new MutableStruct { x = 10 };
        }
        
        static void Main()
        {
            var args = new object[] { new MutableStruct() };
            var method = typeof(Test).GetMethod("ChangeByRef");
            method.Invoke(null, args);
            var changed = (MutableStruct) args[0];
            Console.WriteLine(changed.x); // Prints 10
        }
    }
