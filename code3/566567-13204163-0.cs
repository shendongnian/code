    public class Leader
    {
       public string Name { get; set; }
       public string Precinct { get; set; }
    }
 
    public class MarketReport
    {
       public List<Leader> Leaders { get; set }
    }
    this.Leaders = new List<Leader>();
    foreach (var store in stores)
    {
        var leader = new Leader { ... };
        this.Leaders.Add(leader);
    }
