    public class VenuePart
    {
    }
    public class HoleVenuePart : VenuePart
    {
    }
    public interface IPartCollection<T> where T : VenuePart
    {
      ICollection<T> Parts { get; set; }
    }
    public abstract class Venue<T> : IPartCollection<T> where T : VenuePart
    {
      public int Id { get; set; }
      public string Name { get; set; }
      //public virtual Company Company { get; set; }
      public virtual ICollection<T> Parts { get; set; }
    }
    public class GolfCourseVenue : Venue<HoleVenuePart>
    {
      public string Slope { get; set; }
      ICollection<HoleVenuePart> IPartCollection<HoleVenuePart>.Parts { get { return base.Parts; } set { base.Parts = value; }}
    
      public virtual ICollection<HoleVenuePart> Holes { get { return base.Parts; } set { base.Parts = value;}}
    }
