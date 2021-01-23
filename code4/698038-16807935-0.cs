    [ProtoContract]
    public class SomeWrapper
    {
        [ProtoMember(1)]
        public List<Person> People { get { return people; } }
    
        private readonly List<Person> people = new List<Person>();
    }
