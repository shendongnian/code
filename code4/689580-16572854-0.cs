    public interface IUIConcern
    {
        string Name { get; }
    }
    public interface IUIConcern<out T> : IUIConcern where T : IUIConcernExtension
    {
        Func<T> Extern();
    }
