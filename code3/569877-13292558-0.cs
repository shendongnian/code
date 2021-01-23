    public interface IGeometry
    {
        bool IsOverlapping(IGeometry geometry);
    }
    public class Circle2D : IGeometry
    {
        public bool IsOverlapping(IGeometry geometry)
        {
            dynamic dyn = geometry;
            return overlap(dyn);
        }
        private bool overlap(Box2D box)
        {
            // overlapping logic...
        }
        private bool overlap(Circle2D circle)
        { 
            // overlapping logic...
        }
    }
    public class Box2D : IGeometry
    {
        public bool IsOverlapping(IGeometry geometry)
        {
            dynamic dyn = geometry;
            return overlap(dyn);
        }
        private bool overlap(Box2D box)
        { 
            // overlapping logic...
        }
        private bool overlap(Circle2D circle)
        { 
            // overlapping logic...
        }
    }
