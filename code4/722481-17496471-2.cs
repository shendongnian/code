    public interface ICar
    {
        IEngine Engine { get; set; }
    }
    public abstract class Car<T>
        : ICar
        where T : IEngine
    {
        public T Engine { get; set; }
        IEngine ICar.Engine { get { return Engine; } set { Engine = (T)value; } }
    }
