    public class Dates
    {
    	public string DateAdded { get; set; }
    }
    
    List<Dates> dates = new List<Dates> {new Dates {DateAdded = "7/24/2012"}, new Dates {DateAdded = "7/25/2012"}};
    
    void Main()
    {
    	DateEqualToThisDate("7/25/2012").Dump();
    }
    
    public List<Dates> DateEqualToThisDate(string anything)
    {
    	var dateToCompare = DateTime.Parse(anything);
    	
    	List<Dates> hireDates = dates.Where(n => DateTime.Parse(n.DateAdded) == dateToCompare).ToList();
    	
    	return hireDates;
    }
