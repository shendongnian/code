    public interface IName
    {
        IAge WithName(string name);
    }
    
    public interface IAge
    {
        IPersist WithAge(int age);
    }
    
    public interface IPersist
    {
        void Save();
    }
    
    public class Person : IName, IAge, IPersist
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
    
    
        public IAge WithName(string name)
        {
            Name = name;
            return this;
        }
    
        public IPersist WithAge(int age)
        {
            Age = age;
            return this;
        }
    
        public void Save()
        {
            // save changes here
        }
    }
