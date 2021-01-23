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
