    public class CompoundBoundingShape : IBoundingShape
    {
        public CompoundBoundingShape()
        {
            Shapes = new List<IBoundingShape>();
        }
        public List<IBoundingShape> Shapes { get; private set; }
        public bool Interesects(Rectangle rect)
        {
            foreach (var shape in Shapes)
            {
                if (shape.Intersects(rect))
                    return true;
            }
            
            return false;
        }
    }
