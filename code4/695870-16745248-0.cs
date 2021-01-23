    public interface IConsoleProperty 
    {
        public string handle { get; set; }
        public string description { get; set; }
    }
    
    public class Variable<T> : IConsoleProperty
    {
        public string handle { get; set; }
        public string description { get; set; }
        //Rest of Variable class
    }
    public class Closure : IConsoleProperty
    {
        public string handle { get; set; }
        public string description { get; set; }
        //Rest of Closure class
    }
