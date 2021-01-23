    public interface IVenue 
    { 
        public int Id { get; } 
        public string Name { get; } 
        public virtual IEnumerabe<VenuePart> VenueParts { get; } 
    } 
    
    public interface IGolfCourse : IVenue
    { 
        public virtual IEnumerabe<HoleVenuePart> Holes { get; } 
    } 
