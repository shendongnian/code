    public interface ICar
    {
        IEngine Engine { get; set; }
    }
    public abstract class Car<T>
        : ICar
        where T : IEngine
    {
        // This is the property that you'll see when you have a strongly typed variable.
        // The type of the engine will be the exact type, so you have all its properties.
        public T Engine { get; set; }
        // This is the property that you'll see when your variable is of type ICar.
        // It will only expose the properties that are on the `IEngine` interface, even
        // though the object itself will be of the correct type.
        IEngine ICar.Engine { get { return Engine; } set { Engine = (T)value; } }
    }
