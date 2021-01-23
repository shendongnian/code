    using System;
    using System.Runtime.InteropServices;
    
    struct Data
    {
        public int number;
        public string message;
    }
    
    class Managed
    {
        [DllImport("unmanaged")]
        extern static void Foo(out Data data);
        static void Main()
        {
            Data data;
            Foo(out data);
            Console.WriteLine("number = {0}, message = {1}", data.number, data.message);
        }
    }
