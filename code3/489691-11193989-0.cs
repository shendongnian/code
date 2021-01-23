    public enum OptimizeFor
    {
        Unspecified,
        Speed,
        Accuracy
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Some sample arguments passed in. 
            args = new[] {"-o", "SPEED", "accuracy", "SomethingElse"};
            var matchingEnumValues = Enum.GetNames(typeof (OptimizeFor))
                .Intersect(args, StringComparer.InvariantCultureIgnoreCase)
                .Select(i => Enum.Parse(typeof(OptimizeFor),i))
                .ToList();
            matchingEnumValues.ForEach(Console.WriteLine);
            Console.Read();
        }
    }
