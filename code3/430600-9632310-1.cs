    public class Basehandler 
    {
    	public void Handle<TCommand>(T command) where TCommand : ICommand {
    		((dynamic)this).Handler(command);
    	}
    	
    	// As fallback if there is no implementation for the command type
    	public void Handler(ICommand val) {
            // You could implement default or error handling here.
            Console.WriteLine(val == null ? "null" : val.GetType().ToString());
    	}
    }
