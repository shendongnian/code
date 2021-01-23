    class Rectangle
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    
        public IEnumerable<Point> RandomPoints(Random rnd)
        {
            while (true)
            {
                yield return new Point(rnd.NextDouble() * Width,
                                       rnd.NextDouble() * Height);
            }
        }
    }
