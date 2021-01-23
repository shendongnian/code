    public interface IName
    {
       string Name { get; set; }
    }
    
    
    public interface INumber
    {
       string PhoneNumber { get; set; }
    }
    
    
    public class Worker : IName, INumber
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
