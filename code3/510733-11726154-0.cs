    // List of strings formated like {itemname}-{x}-{y}-{z}
    List<string> test = new List<string>
    {
    	"name1-1-1-2",
    	"name2-0-1-2",
    	"name3-0-0-3"
    };
    
    var res = test
    	.Select(tmp =>
    		{
    			string[] items = tmp.Split('-');
    			return new
    				{
    					x = int.Parse(items[1]),
    					y = int.Parse(items[2]),
    					z = int.Parse(items[3])
    				};
    		})
    	.Where(tmp => (tmp.x + tmp.y + tmp.z) < 4)  // Insert the right math formula here.
    	.ToList();
