    public class BinaryProblemFactory : IProblemFactory
    {
        private BinaryProblemConfiguration _config;
        private Random _random;
    
        public BinaryProblemFactory(BinaryProblemConfiguration config)
        {
            _config = config;
            // or you can use const seed here
            _random = new Random(DateTime.Now.Millisecond); 
        }
    
        public override Problem CreateProblem()
        {
            var x = GenerateValueInRange(_config.XRange);
            var y = GenerateValueInRange(_config.YRange);
            return new BinaryProblem(x, y);
        }
    
        private decimal GenerateValueInRange(Range<int> range)
        {
            return _random.Next(range.Min, range.Max);
        }
    }
