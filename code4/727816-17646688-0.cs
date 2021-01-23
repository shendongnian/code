    void Main()
    {
    	var input = new [] {
    							"junk ....",
    							"Title Mr .....",
    							"alias johnsmith...",
    							"alias john.smith...",
    							"Salutation ...",
    							"junk ...",
    							"junk ....",
    							"Title Mrs .....",
    							"alias janesmith...",
    							"alias jane.smith...",
    							"Salutation ...",
    							"junk ..."
    						};
    	
    	for (int i = 0; i < input.Count(); i++)
    	{
    		if(input[i].StartsWith("Title"))
    		{
    			var tempUser = new user();
    			tempUser.Title = input[i];
    			i++;
    			while(input[i].StartsWith("alias"))
    			{
    				tempUser.Aliases.Add(input[i]);
    				i++;
    			}
    			
    			if(input[i].StartsWith("Salutation"))
    			{
    				tempUser.Salutation = input[i];
    			}
    			tempUser.Dump();
    		}
    	}
    }
    
    public class user
    {
    	public user()
    	{
    		Aliases = new List<string>();
    	}
    	public string Title { get; set;}
    	public string Salutation { get; set;}
    	public List<string> Aliases { get; set;}
    }
