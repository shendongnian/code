    public class Car {
        public Engine Engine { get; private set; }
        public Car(Engine engine) {
            Engine = engine;
        }
    }
    public class SportsCar: Car {
        public new SportsEngine Engine { 
            get { return (SportsEngine)base.Engine; } 
        }
        public SportsCar(SportsEngine engine): base(engine) {}
    }
