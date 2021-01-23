    void Main()
    {
    	var list = new List<Group>{
    	    new Group { Name = "Group1", Type = 1 },
    	    new Group { Name = "Group2", Type = 2 },
    	    new Group { Name = "Group3", Type = 1 },
    	    new Group { Name = "Group4", Type = 1 },
    	    new Group { Name = "Group5", Type = 1 },
    	    new Group { Name = "Group6", Type = 2 },
    	    new Group { Name = "Group7", Type = 3 },
    	    new Group { Name = "Group8", Type = 2 },
    	    new Group { Name = "Group9", Type = 3 },
    	    new Group { Name = "Group10", Type = 3 }
    	};
    	
    	var groups = list.GroupBy(g => g.Type).ToList();	
    	var groupCounts = groups.Select(g => g.Count()).ToArray();	
        var biggestGroup = groupCounts.Max();
    	
    	var newList = new List<Group>();
    	for (int i = 0; i < biggestGroup; i++)
    	{
    	    for (int j = 0; j < groups.Count && i < groupCounts[j]; j++)
    	    {
    	        var element = groups[j].ElementAt(i);
    	        newList.Add(element);
    	    }
    	}	
    	
        // newList contains the ordered items
    }
    
    public class Group 
    {
    	public string Name { get;set; }
    	
    	public int Type { get;set; }
    }
