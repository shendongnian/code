<!-- -->
    public interface IMyBusinessObjectType
    {
        string Name { get; }
    }
    
    public class MyBusinessObjectType : IMyBusinessObjectType
    {
        public string Name { get; set; }
    }
