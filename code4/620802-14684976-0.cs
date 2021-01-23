    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void CreatePoint(int x, int y)
        {
            // Doesn't work either
            this = new Point();
        }
    }
