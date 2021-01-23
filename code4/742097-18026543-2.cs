    public class CircleAndBox
    {
        public Circle Circle { get; private set; }
        public Box Box { get; private set; }
        public CircleAndBox()
        {
            Circle = new Circle();
            Box = new Box();
        }
        public CircleAndBox Radius(string radius)
        {
            Circle.Radius(radius);
            return this;
        }
        public CircleAndBox Width(string width)
        {
            Box.Width(width);
            return this;
        }
        public static implicit operator Circle(CircleAndBox self)
        {
            return self == null ? null : self.Circle;
        }
        public static implicit operator Box(CircleAndBox self)
        {
            return self == null ? null : self.Box;
        }
    }
