    public interface ISecond
    {
    	// some properties	
    }
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
    	
    	private class SecondClass : ISecond
    	{
    		// some properties  
    	
    		public SecondClass() { }
    	
    		public void Update(/*parameters*/)
    		{       
    			// do something
    		}
    	}
    }
