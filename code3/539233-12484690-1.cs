    public interface IItem<out T> where T : IFoo
    {
        // IEnumerable<IBar<T>> GetList(); // works
        IEnumerable<IBar<T>> ItemList { get; } // also works
    }
