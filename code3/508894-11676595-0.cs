    public interface ICrazyObject
    {
        DateTime Date { get; }
        string Type { get; }
    }
    
    public class Dog : ICrazyObject
    {
        public Dog(string type)
        {
            Type = type;
        }
    
        public DateTime Date { get; }
        public string Type { get; }
    }
    
    public class Car : ICrazyObject
    {
        public Car(string type)
        {
            Type = type;
        }
    
        public DateTime Date { get; }
        public string Type { get; }
    }
