    class FizzBuzzFormatter : IOutputFormatter
    {
        public bool Handles(int value) { return value.IsDivisibleBy(15); }
        public string Handle(int value) { return "FizzBuzz"; }
    }
