    public interface IShape
    {
        int area { get; }
    }
    public interface IFindWindow: IShape
    {
        string WindowName { get; }
    }
