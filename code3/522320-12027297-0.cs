    public class Shape
    {
        protected int _radius;
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
    }
    public class Hexagon : Shape
    {
        int _points;
        public void SetRadius(int radius)
        {
            this.Radius = radius;
        }
    }
