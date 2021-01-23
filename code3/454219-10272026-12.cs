    public class Point
    {
        public int Id { get; set; }
        public int XVal {get; set;}
        public int YVal {get; set;}
    }
    public class Line
    {
        public int Id {get; set;}
        public Point StartPoint {get; set;}
        public Point EndPoint {get; set;}
    }
    public class Polygon
    {
        public Polygon()
        {
            Lines = new HashSet<Line>();
        }
        public int Id {get; set;}
        public string Description { get; set; }
        public ICollection<Line> Lines { get; set; }
    }
