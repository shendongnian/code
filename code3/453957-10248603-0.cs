    void Main()
    {
        var things = Enumerable
    			.Range(1, 2000000)
    			.Select(r => new Thing {Description = r.ToString()})
    			.ToList();
    	
    	var times = Enumerable.Range(1, 10)
    		.Select(t => new
    			{	
    				Method1 = Test(Method1, things),
    				Method2 = Test(Method2, things),
    			}
    	).ToList();
    	var average = new {
    			Method1 = TimeSpan.FromMilliseconds( times.Sum(t=>t.Method1.TotalMilliseconds) / times.Count),
    			Method2 = TimeSpan.FromMilliseconds( times.Sum(t=>t.Method2.TotalMilliseconds) / times.Count),
    	};
    	average.Dump();
    }
    
    public TimeSpan Test(Action<IEnumerable<Thing>> action, IEnumerable<Thing> things)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        action(things);
        stopWatch.Stop();
        return stopWatch.Elapsed;
    }
    
    public void Method1(IEnumerable<Thing> things)
    {
    	var sb = new StringBuilder();
    	using (var stringWriter = new StringWriter(sb) )
    	{
    		using (var htmlWriter = new HtmlTextWriter(stringWriter))
    		{					
    			foreach (var thing in things)
    			{
    				htmlWriter.Write(thing.Description);
    			}
    		}
    	}	
    }
    
    
    public void Method2(IEnumerable<Thing> things)
    {
    	var thingsBuilder = new StringBuilder();
    	foreach ( var thing in things)
    		thingsBuilder.Append(thing.Description);
    	var thingsText = thingsBuilder.ToString();
    	var sb = new StringBuilder();
    	using (var stringWriter = new StringWriter(sb) )
    	{
    		using (var htmlWriter = new HtmlTextWriter(stringWriter))
    		{			
    			htmlWriter.Write(thingsText);					
    		}
    	}	
    }
    
    public class Thing
    {
    	public string Description {get; set;}
    }
    // Define other methods and classes here
    
    (use linq pad)
