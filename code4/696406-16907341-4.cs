    class Program
    {
        static void Main()
        {
            var t1 = new TestClass1();
            
            Console.WriteLine(new SubMember<string>(t1, "SubProperty", "Address").Value);            
        }
    }
