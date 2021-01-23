    public class ExampleArgument
    {
        private readonly int _knownValue;
        private readonly string _arbitraryValue;
        public ExampleArgument(string arbitraryValue)
        {
            _arbitraryValue = arbitraryValue;
            _knownValue = 0;
        }
        private ExampleArgument(int knownValue)
        {
            _knownValue = knownValue;
            _arbitraryValue = null;
        }
        public static readonly ExampleArgument FirstKnownValue = new ExampleArgument(1);
        public static readonly ExampleArgument SecondKnownValue = new ExampleArgument(2);
        // obvious Equals and GetHashCode overloads
        // possibly other useful methods that depend on the application
    }
