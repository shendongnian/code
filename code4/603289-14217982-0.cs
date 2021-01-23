    public interface ISteppable
    {
        public int StepNumber { get; }
        public void Foo();//the method you need to call; adjust the signature as needed
    }
    
    class step : ISteppable
    {
        int StepNumber;
    
        int ISteppable.StepNumber
        {
            get { return StepNumber; }
        }
    
        public void Foo()
        {
    
        }
    }
    
    class AutoStep
    {
        int StepNumber;
    
        int ISteppable.StepNumber
        {
            get { return StepNumber; }
        }
    
        public void Foo()
        {
    
        }
    }
