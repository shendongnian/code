     public class ShapeFactory
        {
            public static IShape GetShape(ShapeType shapeType)
            {
                switch (shapeType)
                {
                    case ShapeType.Square:
                        return new Square();
                     
                    case ShapeType.Rectangle:
                        return new Rectangle();
                    default:
                        break;
                }
    
                return null;
            }
        }
    
        public enum ShapeType
        {
            Square,
            Rectangle
        }
