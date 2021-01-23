    struct Shape
    {
        public Shape(int width, int height, int xAxis, int yAxis)
        {
            this.width = width;
            this.height = height;
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }
    
        private int width;
        private int height;
        private int xAxis;
        private int yAxis;
    
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int XAxis { get { return xAxis; } }
        public int YAxis { get { return yAxis; } }
    }
