    class Program
    {
        static void Main()
        {
            Console.WriteLine(new TestClass().ViewModelPropertyName("FirstName"));
            Console.WriteLine(new TestClass().ViewModelPropertyName("LastName"));
            Console.Read();
        }
    }
