    public class O1
    {
    	public string Ids { get; set; }
    	public DateTime Time { get; set; }
    	public int Passes { get; set; }
    }
    
    public class O2
    {
    	public int Id { get; set; }
    	public DateTime Time { get; set; }
    	public int Passes { get; set; }
    }
    
    static void Main(string[] args)
    {
    	var o1 = new O1();
    	o1.Ids = "1,2,3,4,5";
    	o1.Time = DateTime.Now;
    	o1.Passes = 42;
    
    	var results = o1.Ids.Split(',').Select(r => new O2 { Id = int.Parse(r), Time = o1.Time, Passes = o1.Passes });
    	foreach (var item in results)
    	{
    		Console.WriteLine("{0}: {1} {2}", item.Id, item.Time, item.Passes);
    	}
    }
