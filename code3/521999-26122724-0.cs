    class Shape
    {
        public int width, height;
        public Shape(int x)
        {
            width = height = x;
        }
        public Shape(Shape shape)
        {
            width = shape.width;
            height = shape.height;
        }
    }
    class Triangle : Shape
    {
        public string style;
        public Triangle(int x)
            : base(x)
        {
            style = "isosceles";
        }
        public Triangle(Triangle triangle)
            : base(triangle)
        {
            style = triangle.style;
        }
    }
    class Draw
    {
        static void Main()
        {
            Triangle triangle1 = new Triangle(5);
            Triangle triangle2 = new Triangle(triangle1);
        }
    }
