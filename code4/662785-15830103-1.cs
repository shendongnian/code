    public class Fixture 
    {
        public string Name { get; set; }
        public List<Participant> Participants { get; set; }
    
        public override bool Equals(object obj)
        {
            var fixture = obj as Fixture;
            return fixture == null ? false : fixture.Name == Name;
        }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
    
    public class Participant 
    {
        public string Name { get; set; }
    
        public override bool Equals(object obj)
        {
            var participant = obj as Participant;
            return participant == null ? false : participant.Name == Name;
        }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
