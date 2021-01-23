    class HandleTypes
    {
        public HandleTypes(Type type)
        {
            if (type.GetCustomAttributes<SpecialAttribute>().Any())
            {
                Console.WriteLine("Special case...");
            }
            else
            {
                Console.WriteLine("Standard case...");
            }
        }
    }
