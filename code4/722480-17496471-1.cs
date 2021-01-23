    public abstract class Car<T> 
        where T : Engine
    {
        public T Engine { get;set; }
    }
    public class Car : Car<Engine> { }
    public class SportsCar : Car<TurboEngine> { }
    public class SuperCar : Car<FormulaOneEngine> { }
