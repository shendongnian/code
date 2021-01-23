    using System;
    using Mono.Addins;
    
    [assembly:AddinRoot ("HelloWorld", "1.0")]
    
    class MainClass
    {
    	public static void Main ()
    	{
    		AddinManager.Initialize ();
    		AddinManager.Registry.Update ();
    		
    		foreach (ICommand cmd in AddinManager.GetExtensionObjects<ICommand> ())
    			cmd.Run ();
    	}
    }
