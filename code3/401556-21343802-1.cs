    void Main()
    {
    	List<Sample> series = new List<Sample>();
    	
    	Random random = new Random(DateTime.Now.Millisecond);
    	for (DateTime i = DateTime.Now.AddDays(-5); i < DateTime.Now; i += TimeSpan.FromMinutes(1))
    	{
    		series.Add(new UserQuery.Sample(){ timestamp = i, value = random.NextDouble() * 100 });
    	}
    	//series.Dump();
    	series.GroupBy (s => s.timestamp.Ticks / TimeSpan.FromHours(1).Ticks)
    		.Select (s => new {
    			series = s
    			,timestamp = s.First ().timestamp
    			,average = s.Average (x => x.value )
    		}).Dump();
    }
    
    // Define other methods and classes here
    public class Sample
    {
         public DateTime timestamp;
         public double value;
    }
