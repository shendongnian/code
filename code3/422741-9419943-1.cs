    [DataContract]
    public abstract class MyAbstract
    {
    	protected readonly Dictionary<int, string> myDict;
        protected MyAbstract()
        {
            OnCreated();
        }
        private void OnCreated()
        {
            myDict = new Dictionary<int, string>();
        }
        [OnDeserializing]
        private void OnDeserializing(StreamingContext c)
        {
            OnCreated();
        }
    
    	private bool MyMethod(int key)
    	{
    		return myDict.ContainsKey(key);
    	}
    
    	private int myProp;
    
    	[DataMember]
    	public int MyProp
    	{
    		get { return myProp; }
    		set { bool b = MyMethod(value); myProp = value; }
    	}
    }
