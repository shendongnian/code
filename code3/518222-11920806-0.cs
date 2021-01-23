    public class Cube {
        private readonly Point center = new Point();
        public Point Center {
            get {
                return center.Clone();
            }
            set {
                center.X = value.X;
                center.Y = value.Y;
            }
        }
        ... // some more cube properties
    }
