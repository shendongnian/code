        bool IsOverlapping(IGeometry geometry);
    }
    public class Circle2D : IGeometry
    {
        public bool IsOverlapping(IGeometry geometry)
        {
            dynamic dyn = geometry;
            return Overlapper.Overlap(this, dyn);
        }
    }
    public class Box2D : IGeometry
    {
        public bool IsOverlapping(IGeometry geometry)
        {
            dynamic dyn = geometry;
            return Overlapper.Overlap(this, dyn);
        }
    }
    public static class Overlapper
    {
        public static bool Overlap(Box2D box1, Box2D box2)
        {
            // logic goes here
        }
        public static bool Overlap(Box2D box1, Circle2D circle1)
        {
            // logic goes here
        }
        public static bool Overlap(Circle2D circle1, Box2D box1)
        {
            return Overlap(box1, circle1); // No need to rewrite it twice
        }
        public static bool Overlap(Circle2D circle1, Circle2D circle2)
        { 
            // logic goes here
        }
    }
