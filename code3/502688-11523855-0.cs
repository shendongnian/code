    public interface IShape
    {
        int NumberOfLineSegments {get;}
        float Area{get;}
    }
    
    public class Rectangle
    {
        public int NumberOfLineSegments { get { return 4; } }
    }
    
    public sealed class Square : Rectangle, IShape
    {
        public float Area() { get { return length*height; }
    }
