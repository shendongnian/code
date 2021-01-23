    public class QShape {
        public abstract void Grow(int amt);
    }
    public class QSquare : QShape {
        private int sideLength;
        public override void Grow(int amt)
        {
            sideLength+=amt;
        }
    }
    public class QCircle : QShape {
        private int radius;
        public override void Grow(int amt)
        {
            radius+=amt;
        }
    }
