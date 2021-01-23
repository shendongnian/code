    class Program
    {
        static void Main()
        {
            var builder = new PredicateBuilder<SomeEntity>();
            for (int i = 0; i < 1000000; i++) // Create 1,000,000 expressions
            {
                builder.AddCondition("OrderID", "42");
                Console.Title = i.ToString();
            }
            builder.Compile();
        }
    }
