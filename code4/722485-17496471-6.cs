    public interface ICar
    {
        IEngine Engine { get; set; }
    }
    public abstract class BaseCar<T>
        : ICar
        where T : IEngine
    {
        public T Engine { get; set; }
        IEngine ICar.Engine { get { return Engine; } set { Engine = (T)value; } }
    }
    public class Car : BaseCar<Engine>, ICar { }
    public class SportsCar : Car, ICar
    {
        IEngine ICar.Engine
        {
            get { return Engine; }
            set { Engine = (TurboEngine)value; }
        }
        public new TurboEngine Engine
        {
            get { return (TurboEngine)base.Engine; }
            set { base.Engine = value; }
        }
    }
    public interface ISportsCar<T> : ICar where T : TurboEngine { }
    public class SuperCar : SportsCar, ISportsCar<FormulaOneEngine>
    {
        public new FormulaOneEngine Engine
        {
            get { return (FormulaOneEngine)base.Engine; }
            set { base.Engine = value; }
        }
    }
    public interface IEngine { }
    public class Engine : IEngine { }
    public class TurboEngine : Engine { }
    public class FormulaOneEngine : TurboEngine { }
