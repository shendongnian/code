    public delegate void Del(string message);
    public class MenuItem
    {
    	private Del _triggerMethod;
    	public void Trigger()
    	{
    		_triggerMethod("Message");
    	}
    }
