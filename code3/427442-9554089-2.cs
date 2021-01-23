    public class EditorCreationVisitor : IShapeVisitor{
        IShapeEditor editor;
        public void VisitSquare(Square s ){
            editor = new SquareEditor(s);
        }
        public void VisitTriangle(Triangle t ){
            editor = new TriangleEditor(t);
        }
        public void VisitCircle(Circle c ){
            editor = new CircleEditor(c);
        }
        public IShapeEditor Editor {get{return editor;}}
    }
