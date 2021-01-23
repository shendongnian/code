	public abstract class VenuePart
	{
		public abstract string NameDescriptor { get; }
	}
	
	public class HoleVenuePart : VenuePart
	{
		public override string NameDescriptor { get{return "I'm a hole venue"; } }
	}
	
	public abstract class Venue 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public abstract ICollection<VenuePart> VenueParts { get; }
	}
	
	public class GolfCourseVenue : Venue
	{
		private ICollection<HoleVenuePart> _holeVenueParts;
		
		public GolfCourseVenue(ICollection<HoleVenuePart> parts)
		{
		   _holeVenueParts = parts;
		}
		public override ICollection<VenuePart> VenueParts 
		{ 
			get
			{ 
				// Here we need to prevent clients adding
				// new VenuePart to the VenueParts collection. 
				// They have to use Add(HoleVenuePart part).
				// Unfortunately only interfaces are covariant not types.
				return new ReadOnlyCollection<VenuePart>(
                       _holeVenueParts.OfType<VenuePart>().ToList()); 
			} 
		}
		public void Add(HoleVenuePart part) { _holeVenueParts.Add(part); }
	}
