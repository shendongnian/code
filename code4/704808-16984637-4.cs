    public class FirstClass
    {
    	private readonly SecondClass _TheField;
        public ISecond TheField { get { return _TheField; } }
    
        public FirstClass()
        {
            _TheField = new SecondClass();
        }
    
        public void SomeMethod()
        {
            // ...
            _TheField.Update(/*parameters*/);
            // ...
        }
    	private class SecondClass : SecondClassBase
    	{
    		public SecondClass() { }
    	
    		public new void Update(/*parameters*/)
    		{       
    			base.Update(/*parameters*/);
    		}
    	}
    }
