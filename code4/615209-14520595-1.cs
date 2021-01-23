    public interface IEngine 
    {
         void Start();
    }
    
    public sealed class FerrariEngine : IEngine
    {
         public FerrariEngine()
         {
              Start();
         }
    
         public void Start()
         {
         }
    }
    
    public abstract class Car<TEngine> where TEngine: IEngine, new()
    {
        public Car()
        {
            _engine = new Lazy<TEngine>(() => new TEngine());
        }
    
        private readonly Lazy<TEngine> _engine;
    
        public TEngine Engine
        {
            get { return _engine.Value; }
        }
    }
    
    public class FerrariCar : Car<FerrariEngine>
    {
    }
