    public interface IConfiguration
    {
        int GetRandomNumber();
    }
    
    public abstract class Configuration
    {
        protected abstract Bound<int> Bound1 { get; }
        protected abstract Bound<int> Bound2 { get; }
        public int GetRandomNumber()
        {
            //get random number impl
        }
    }
    
    public class MediumLevelConfiguration : Configuration
    {
        protected override Bound<int> Bound1
        {
            get { return new Bound<int>(100, 1000); }
        }
    
        protected override Bound<int> Bound2
        {
            get { return new Bound<int>(10, 100); }
        }   
    }
