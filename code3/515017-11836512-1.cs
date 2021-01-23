    interface IEngine
    {
        void FillUpFuel(int amountOfFuel, int maxAmountOfFuel);
    }
    class ElectricEngine : IEngine
    {
        public void FillUpFuel(int amountOfFuel, int maxAmountOfFuel) { ... }
    }
    abstract class Vehicle
    {
        public abstract IEngine Engine { get; }
    }
    class Car : Vehicle
    {
        public IEngine _engine;
        public override IEngine Engine { get { return _engine; } }
        public Car(IEngine engine)
        {
            _engine = engine;
        }
    }
    ...
    var electricCar = new Car(new ElectricEngine());
    electricCar.Engine.FillUpFuel(40, 70);
