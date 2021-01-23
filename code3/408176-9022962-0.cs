    // purely for illustrative purposes
    public interface IShape { }
    public class Rectangle : IShape { }
    // represents your more "generic" interface
    public interface ShapeMaker
    {
        List<IShape> GetShapes();
    }
    // Your specific implementation
    public class RectangleMaker : ShapeMaker
    {
        // the explicit implementation of the interface satisfies the 
        // original, and behaves like original when called from an ShapeMaker 
        // interface reference
        List<IShape> ShapeMaker.GetShapes()
        {
            return new List<IShape>();
        }
        // but, we also provide an overload that returns a more specific version
        // when used with a reference to our subclass.  This gives us more 
        // functionality.
        public List<Rectangle> GetShapes()
        {
            return new List<Rectangle>();
        }
    }
