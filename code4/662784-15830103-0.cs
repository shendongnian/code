    public class Fixture : IEquatable<Fixture>
    {
        public string Name { get; set; }
        public List<Participant> Participants { get; set; }
    
        public override bool Equals(object obj)
        {
            var fixture = obj as Fixture;
            return fixture == null ? false : Equals(fixture);
        }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    
        public bool Equals(Fixture other)
        {
            return other.Name == Name;
        }
    }
    
    public class Participant : IEquatable<Participant>
    {
        public string Name { get; set; }
    
        public override bool Equals(object obj)
        {
            var participant = obj as Participant;
            return participant == null ? false : Equals(participant);
        }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    
        public bool Equals(Participant other)
        {
            return other.Name == Name;
        }
    }
