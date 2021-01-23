    public interface IEngine
    {
         void Start();
         void Stop();
         void Diagnose();
    }
    
    
    public abstract class Car
    {
        protected Car(IEngine engine)
        {
             Engine = engine;
        }
    
        protected IEngine Engine {get; set;}
    
        public void Start() {
            engine.Start();
            // do something else
        }
    
        public void Stop() {
            engine.Stop();
            // do something else
        }
    
        public void Diagnose() {
            engine.Diagnose();
            // anotherField.Diagnose();
            // oneAnotherField.Diagnose();
        }
    }
    
    public class ConcreteCar : Car
    {
        public ConcreteCar(IEngine engine):base(engine)  // injection by constructor
        {
        }
    
        ...
    }
