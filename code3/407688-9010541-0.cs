    public interface IName
    {
       string Name { get; set; }
    }
    
    
    public interface IName
    {
       string PhoneNumber { get; set; }
    }
    
    
    public class Woker : IName, INumber
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
