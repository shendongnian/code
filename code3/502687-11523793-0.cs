    public interface IShape : ICalculateArea, IHaveLineSegments
    {
    }
    
    public interface ICalculateArea
    {
        float Area { get; }
    }
    
    public interface IHaveLineSegments
    {
        int NumberOfLineSegments { get; }
    }
    class Rectangle : IHaveLineSegments
    {
        public int NumberOfLineSegments { get; private set; }
    }
    class Square : Rectangle, IShape
    {
        public float Area { get; private set; }
    }
