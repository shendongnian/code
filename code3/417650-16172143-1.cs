    private ObservableCollection<Point> m_points;
    public ObservableCollection<Point> Points
    {
        get { return m_points; }
        set { m_points = value; }
    }
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
