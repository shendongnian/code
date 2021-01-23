    class BaseClass 
    { 
        public BaseClass() { } 
    
        protected string methodName; 
        protected int noOfTimes; 
        public void Execute(string MethodName, int NoOfTimes) 
        { 
            this.methodName = MethodName; 
            this.noOfTimes = NoOfTimes;
            doWork();
        } 
    
        protected virtual void doWork() {
            // default behaviour, can be modified by subclasses
        }
    } 
