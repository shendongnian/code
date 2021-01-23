    public interface IShape
    {
        int area { get; }
    }
    public interface IShapeEx : IShape
    {
        string WindowName { get; }
    }
