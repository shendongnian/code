    public class SomeConsumer : IConsumer
    {
        private readonly IIndex<Type, IProcessing> _processors;
        public SomeConsumer(IIndex<Type, IProcessing> processors)
        {
            _processors = processors;
        }
        public void DoStuff()
        {
            var someRequest = new MathRequest();
            var someResponse = _processors[someRequest.GetType()].Process(someRequest);
        }
    }
