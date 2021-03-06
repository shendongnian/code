    public abstract class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Company Company { get; set; }
        public virtual IEnumerable<VenuePart> VenueParts { get; set; }
    }
    public class GolfCourseVenue : Venue
    {
        public string Slope { get; set; }
        
        public  GolfCourseVenue()
        {
            List<HoleVenuePart> HoleVenueParts = new List<HoleVenuePart>();
            HoleVenueParts.Add(new HoleVenuePart());
            VenueParts = HoleVenueParts;
        }
    }
