    public interface IThing
    {
        string Name { get; set; }
    }
    public class Thing : IThing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IThing SpecificThing { get; set; }
        public IEnumerable<IThing> Things { get; set; }
    }
