    class TestClass
    {
        static void Main(string[] args)
        {
            // avoiding empty/null checks for simplicity
            string connectionString = args[n]; // where "n" is index value of your
                                               // connection string argument
            DoWork(connectionString);
        }
    }
