    using System;
    using Mono.Addins;
    
    [assembly:Addin]
    [assembly:AddinDependency ("HelloWorld", "1.0")]
    
    [Extension]
    public class HelloCommand: ICommand
    {
    	public void Run ()
    	{
    		Console.WriteLine ("Hello World!");
    	}
    }
