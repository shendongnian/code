    public interface IShape
    {
        int NumberOfLineSegments {get;}
        float Area{get;}
    }
    public abstract class RectangleBase : IShape
    {
        public int NumberOfLineSegments { get { return 4; } }
        public abstract float Area { get; }
    }
    public sealed class Square : RectangleBase
    {
        public override fload Area() { get { return length*height; }
    }
