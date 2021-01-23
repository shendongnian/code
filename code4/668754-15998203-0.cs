    interface IShapeMaker {
        IShape Make(IList<Point> points);
    }
    class RectMaker : IShapeMaker {
        public Make(IList<Point> points) {
            // Check if the points are good to make a rectangle
            ...
            if (pointsAreGoodForRectangle) {
                return new Rectangle(...);
            }
            return null; // Cannot make a rectangle
        }
    }
    class PolylineMaker : IShapeMaker {
        public Make(IList<Point> points) {
            // Check if the points are good to make a polyline
            ...
            if (pointsAreGoodForPolyline) {
                return new Polyline(...);
            }
            return null; // Cannot make a polyline
        }
    }
