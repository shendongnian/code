    using System;
    
    interface IPerl
    {
        void Read();
    }
    
    class Test : IPerl
    {
        public void Read()
        {
    	Console.WriteLine("Read Test");
        }
    }
    
    class Test1 : IPerl
    {
        public void Read()
        {
    	Console.WriteLine("Read Test1");
        }
    }
    
    class Program
    {
        static void Main()
        {
    	IPerl perl = new Test(); // Create instance of Test.
    	perl.Read(); // Call method on interface output will be different then Test1.
    
            perl = new Test1(); // Create instance of Test1.
    	perl.Read(); // Call method on interface output will be different then Test.
    
        }
    }
