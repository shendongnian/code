    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
    public class Service : IService
    {
    
        public static int _counter = 0;
    
    	public string GetData()
    	{
            _counter++;
            return _counter.ToString();
    	}
    }
