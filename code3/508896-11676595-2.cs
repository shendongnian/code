    public enum CrazyObjectType
    {
        Dog,
        Car
    }
    public interface ICrazyObject
    {
        DateTime Date { get; }
        CrazyOjbectType MyObjectType { get; }
    }
    
    public class Dog : ICrazyObject
    {
        public Dog()
        {
            MyObjectType = CrazyObjectType.Dog;
        }
    
        public DateTime Date { get; }
        public CrazyObjectType MyObjectType { get; }
    }
    public class Car : ICrazyObject
    {
        public Car()
        {
            MyObjectType = CrazyObjectType.Car;
        }
    
        public DateTime Date { get; }
        public CrazyObjectType MyObjectType { get; }
    }
    
