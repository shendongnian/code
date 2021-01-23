    public class BaseClass 
    {
        protected BaseClass(GameTime gt) 
        {
            Time = gt;
        }
        
        protected GameTime Time {private set; protected get;}
    
    }
    public class SomeOtherClass : BaseClass
    {
        public SomeOtherClass(GameTime gt) : base(gt)
        {
        }
        public void DoSomething() 
        {
            //can access Time here
        }
    
    }
