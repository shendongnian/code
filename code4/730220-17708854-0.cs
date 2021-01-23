    class Polygon
    {
        public int CountSides { get; set; }
    }
    class Rectangle : Polygon { }
    class Circle : Polygon { }
    class Program
    {
        static void Main(string[] args)
        {
            Polygon p = true ? (Polygon)new Circle() : (Polygon)new Rectangle();
        }
    }
