    public class TestEvent
    {
    	public event EventHandler Event;
    	public void ProcessEvents()
    	{
    		EventHandler e = Event;
    		if(e != null)
    		{
    			e(this, EventArgs.Empty);
    		}
    	}
    }
    
    var te = new TestEvent();
    te.Event += (sender, e) => {
    	//handle event
    };
    te.ProcessEvents();
