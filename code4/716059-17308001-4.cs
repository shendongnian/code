    public class InfoCardSummary
    {
    	public string Name { get; set; }
    	public double Age { get; set; }
    	public string Occupation { get; set; }
    
    	private static readonly string FormattingString = 
    @"This person named {0} is a pretty
    sweet programmer. Even though they're only
    {1}, Acme company is thinking of hiring
    them as a {2}.";
    
    	public string Output()
    	{
    		return String.Format(FormattingString, Name, Age, Occupation);
    	}
    }
    
    var info = new InfoCardSummary { Name = "Kevin DiTraglia", Age = 900, Occupation = "Professional Kite Flier" };
    output = info.Output();
