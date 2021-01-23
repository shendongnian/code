    public class Basehandler 
    {
    	public void Handle<T>(T val) {
    		((dynamic)this).Handler(val);
    	}
    	
    	// As fallback
    	public void Handler(object val) {
    		Console.WriteLine(val == null ? "null" : val.GetType().ToString());
    	}
    }
