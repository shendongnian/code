    using System;
    using System.Collections.Generic;
    
    public class Test
    {
    
    
    	public static void Main()
    	{
    		List<string> Channels = new List<string>() {"a","b", "c"};
    		AddChannel ac = new AddChannel(Channels);
                    ac.AddSomthing("foo");
    
                    foreach(var s in Channels)
    		{
    			Console.WriteLine(s);
    		}
    		
    	}
    
    	
    }
    public class AddChannel 
    {
            private List<string> Channels {get;set;}
    	public AddChannel(List<string> Channels )
            {
    		this.Channels = Channels ; 
    	}
    
            public void AddSomthing(string s)
            {
                this.Channels.Add(s);
            }
     
    }
