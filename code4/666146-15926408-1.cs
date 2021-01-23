    public class CompundBoundingShape : IBoundingShape
    {
        public CompundBoundingShape()
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
