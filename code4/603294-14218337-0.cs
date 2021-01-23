    public interface ISteppable
    {
        public int StepNumber { get; }
        public void Foo();//the method you need to call; adjust the signature as needed
    }
    
    class StepWrapper : ISteppable
    {
        private step m_step;
    
        public StepWrapper(step step)
        {
            m_step = step;
        }
    
        int ISteppable.StepNumber
        {
            get { return step.StepNumber; }
        }
    
        public void Foo()
        {
            step.Something();
        }
    }
