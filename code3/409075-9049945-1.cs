    public interface IConfiguration
    {
         Bound<int> Bound1 { get; }
         Bound<int> Bound2 { get; }
    }
    
    public class EasyLevelConfiguration : IConfiguration
    {
        public Bound<int> Bound1
        {
            get { return new Bound<int>(100, 1000); }
        }
    
        public Bound<int> Bound2
        {
            get { return new Bound<int>(10, 100); }
        }   
    }
