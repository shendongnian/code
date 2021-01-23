    using System;
    using System.Collections.Generic;
    interface iDoc
    {
    }
    class doc : iDoc
    {
        public void meth()
        {
            Console.WriteLine("asdf");
        }
    }
    public class MyClass
    {
        public static void Main()
        {
            var d = new doc();
            d.meth();
            Console.ReadLine();
        }
    }
