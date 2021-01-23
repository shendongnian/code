    public partial class MyClass // partial to the generated class
    {
    	[OnSerializing]
    	public void OnSerializingMethod(StreamingContext context)
    	{
    		foreach(var d  in MyEvent.GetInvocationList())
    		{
    			MyEvent -= (PropertyChangedEventHandler) d;
    		}
    	}
    }
