    public interface IFoo {}
    public interface IBar<out T> where T : IFoo {}
    
    public interface IItem<out T> where T: IFoo
    {
        IEnumerable<IBar<T>> GetList();
    }
