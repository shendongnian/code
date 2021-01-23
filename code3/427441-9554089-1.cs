    public interface IShapeVisitor {
        void VisitSquare(Square s);
        void VisitTriangle(Triangle t);
        void VisitCircle(Circle c);
    }
    public interface IShape {
        void Accept(IShapeVisitor visitor);
    }
 
    public class Square : IShape {
        public void Accept(IShapeVisitor visitor){
            visitor.VisitSquare(this);
        }
    }
    public class Triangle: IShape {
        public void Accept(IShapeVisitor visitor){
            visitor.VisitTriangle(this);
        }
    }
    public class Circle: IShape {
        public void Accept(IShapeVisitor visitor){
            visitor.VisitCircle(this);
        }
    }
