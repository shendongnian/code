    public interface IReadablePerson
    {
        string Name { get; }
    }
    public interface IReadWritePerson : IReadablePerson
    {
        new string Name { get; set; }
        void Save();
    }
    public class Person : IReadWritePerson
    {
        public string Name { get; set; }
        public void Save() {}
    }
