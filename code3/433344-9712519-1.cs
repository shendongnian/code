    public class City
    {
    	private ICollection<Location> _locations;
    
    	public virtual int ID { get; set; }
    	public virtual string Name { get; set; }
    
    	public virtual ICollection<Location> Locations
    	{
    		get { return _locations ?? (_locations = new List<Location>()); }
    		protected set { _locations = value; }
    	}
    }
    
    public class Location 
    {
    	private ICollection<Venue> _venues;
    
    	public virtual int ID {get;set;}
    	public virtual string Name { get; set; }
    
    	public virtual City City {get;set;}
    
    	public virtual ICollection<Venue> Venues
    	{
    		get { return _venues ?? (_venues = new List<Venue>()); }
    		protected set { _venues = value; }
    	}
    }
    
    public class Owner
    {
    	public virtual int ID {get;set;}
    	public virtual string Name { get; set; }
    
    	public virtual int VenueID {get;set;}
    	public virtual Venue Venue {get;set;}
    }
    
    public class Venue
    {
    	public virtual int ID {get;set;}
    	public virtual string Name { get; set; }
    
    	public virtual Location VenueLocation {get;set;}
    
    	public virtual Owner VenueOwner {get;set;}
    }
