    internal class Program
    {
        private static void Main(string[] args)
        {
            var something = new Something();
            something.ComputeValue(13);
            something.ComputeValue(DateTime.Now);
            something.ComputeValue(DayOfWeek.Monday);
            Console.ReadKey();
        }
    }
    internal class Something
    {
        private static Dictionary<Type, Action<object>> _Strategies;
        static Something()
        {
            // Prepare all available strategies.
            _Strategies = new Dictionary<Type, Action<object>>();
            _Strategies.Add(typeof(int), ComputeInteger);
            _Strategies.Add(typeof(DateTime), ComputeDateTime);
        }
        public void ComputeValue(object value)
        {
            Action<object> action;
            // Check if we have a matching strategy.
            if (!_Strategies.TryGetValue(value.GetType(), out action))
            {
                // If not, log error, throw exception, whatever.
                action = LogUnknownType;
            }
            // Perform the matching strategy on the given value.
            action(value);
        }
        private static void ComputeDateTime(object source)
        {
            // We get an object, but we are sure that it will always be an DateTime.
            var value = (DateTime)source;
            Console.WriteLine("We've got an date time: " + value);
        }
        private static void ComputeInteger(object source)
        {
            // We get an object, but we are sure that it will always be an int.
            var value = (int)source;
            Console.WriteLine("We've got an integer: " + value);
        }
        private static void LogUnknownType(object source)
        {
            // What should we do with the drunken sailor?
            var unknownType = source.GetType();
            Console.WriteLine("Don't know how to handle " + unknownType.FullName);
        }
    }
