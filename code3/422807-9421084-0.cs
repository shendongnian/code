    class Request
    {
        private List<string> _data;
        public IEnumerable<string> GetData()
        {
            return _data.AsReadOnly();
        }
        public string AddData(string value)
        {
            _data.Add(value);
        }
    }
    abstract class Step
    {
        protected Step _nextStep;
        public void SetSuccessor(Step step)
        {
            _nextStep = step;
        }
        public abstract void Process(Request request);
    }
    sealed class Step1 : Step
    {
        public override void Process(Request request)
        {
            var data = request.GetData();
            Console.Write("Request processed by");
            foreach (var datum in data)
            {
                Console.Write(" {0} ", datum);
            }
            Console.WriteLine("Now is my turn!");
            request.AddData("step1");
            _nextStep.Process(request);
        }
    }
    // Other steps omitted.
    sealed class Step8 : Step
    {
        public override void Process(Request request)
        {
            var data = request.GetData();
            Console.Write("Request processed by");
            foreach (var datum in data)
            {
                Console.Write(" {0} ", datum);
            }
            Console.WriteLine("Guess we're through, huh?");
        }
    }
    void Main()
    {
         var step1 = new Step1();
         // ...
         var step8 = new Step8();
         step8.SetSuccessor(step1);
         var req = new Request();
         step1.Process(req);
    }
