    public class Grouping
    {
       public int LGA{get;set;}
       public int LGB{get;set;}
       public int El {get;set;}
       public int ElO {get;set;}
    }
    
    void Main()
    {
        var dbValues = new List<Grouping>
    		{
    			new Grouping { LGA =7, LGB = 1, El=6, ElO=2 },
    			new Grouping { LGA =7, LGB = 1, El=3, ElO=1 },
    			new Grouping { LGA =4, LGB = 1, El=3, ElO=1 },
    			new Grouping { LGA =4, LGB = 1, El=6, ElO=2 },
    			new Grouping { LGA =4, LGB = 1, El=7, ElO=3 },
    		};
    	var dbGroups = dbValues.Select(dbData => new {Group = dbData.LGA, Element = dbData.El, ElO = dbData.ElO})
    			.OrderBy(item => item.ElO)
    			.GroupBy(item => item.Group);
    	var elements = new List<int>{3, 6};
    	
    	foreach(var dbGroup in dbGroups)
    	{
    		if (dbGroup.Select(el => el.Element).SequenceEqual(elements))
    		{
    			Console.WriteLine(dbGroup.First().Group);
    		}
    	}
    }
