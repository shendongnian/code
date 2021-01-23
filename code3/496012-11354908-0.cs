    public class QShape
    {
        protected QShape() { }
        public int x { get; set; }
        public int y { get; set; }
        public string colour { get; set; }
    }
    public class QCircle : QShape
    {
        public int radius;
        public QCircle(int theRadius, int theX, int theY, string theColour)
        {
            this.radius = theRadius;
            this.x = theX;
            this.y = theY;
            this.colour = theColour;
        }
    }
    public class QSquare : QShape
    {
        public int sideLength;
        public QSquare(int theSideLength, int theX, int theY, string theColour)
        {
            this.sideLength = theSideLength;
            this.x = theX;
            this.y = theY;
            this.colour = theColour;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<QShape> list = new List<QShape>();
            list.Add(new QCircle(100, 50, 50, "Red"));
            list.Add(new QCircle(100, 400, 400, "Red"));
            list.Add(new QSquare(50, 300, 100, "Blue"));
            foreach (var item in list.OfType<QCircle>())
            {
                item.radius += 10;
            }
            foreach (var item in list.OfType<QSquare>())
            {
                item.sideLength += 10;
            }
        }
    }
