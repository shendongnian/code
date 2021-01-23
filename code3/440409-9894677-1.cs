    public class VenuePart
    {
    }
    
    public class HoleVenuePart : VenuePart
    {
    }
    
    public class Venue 
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public virtual Company Company { get; set; }
    	public virtual ICollection<VenuePart> VenueParts { get; set; }
    }
    
    public class GolfCourseVenue : Venue
    {
    }
