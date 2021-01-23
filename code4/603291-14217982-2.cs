    public class StepAdapter : ISteppable
    {
        private step value;
        public StepAdapter(step value)
        {
            this.value = value;
        }
    
        public int StepNumber
        {
            get { return value.StepNumber; }
        }
    
        public void Foo()
        {
            value.Foo();
        }
    }
    
    public class AutoStepAdapter : ISteppable
    {
        private AutoStep value;
        public AutoStepAdapter(AutoStep value)
        {
            this.value = value;
        }
    
        public int StepNumber
        {
            get { return value.StepNumber; }
        }
    
        public void Foo()
        {
            value.Foo();
        }
    }
