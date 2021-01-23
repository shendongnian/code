    using Mono.Addins;
    
    [TypeExtensionPoint]
    public interface ICommand
    {
    	void Run ();
    }
