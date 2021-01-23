    public class VenuePart
    {
    }
    
    public class HoleVenuePart : VenuePart
    {
    }
    
    public class Venue<T> where T : VenuePart
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public virtual Company Company { get; set; }
    	public virtual ICollection<T> VenueParts { get; set; }
    }
    
    public class GolfCourseVenue : Venue<HoleVenuePart>
    {
    }
