    public abstract class Shape
    {
        public abstract double Area();
        public abstract double Perimeter();
    }
    public class Circle : Shape
    {
        public double Radius;
        public override double Perimeter()
        {
            return 2 * Radius * Math.PI;
        }
        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
    }
    public class Square : Shape
    {
        public double Side;
        public override double Perimeter()
        {
            return Side * 4;
        }
        public override double Area()
        {
            return Side * Side;
        }
    }
    public abstract class Solid
    {
        public abstract double Volume();
    }
    public abstract class CircleBaseSolid : Solid
    {
        protected Circle Base = new Circle();
        public double Radius
        {
            get { return Base.Radius; }
            set { Base.Radius = value; }
        }
        public double Height;
    }
    public class Cylinder : CircleBaseSolid
    {
        public override double Volume()
        {
            return Base.Area() * Height;
        }
    }
    public class Cone : CircleBaseSolid
    {
        public override double Volume()
        {
            return Base.Area() * Height / 3;
        }
    }
    public abstract class SquareBaseSolid : Solid
    {
        protected Square Base = new Square();
        public double Side
        {
            get { return Base.Side; }
            set { Base.Side = value; }
        }
        public double Height;
    }
    public class SquareParallelepiped : SquareBaseSolid
    {
        public override double Volume()
        {
            return Base.Area() * Height;
        }
    }
    public class SquarePyramid : SquareBaseSolid
    {
        public override double Volume()
        {
            return Base.Area() * Height / 3;
        }
    }
