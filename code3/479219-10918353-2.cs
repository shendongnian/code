    public class Rectangle
    {
        private readonly Lazy<int> _area;
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
            _area = new Lazy<int>(() => Height * Width);
        }
        
        public int Height { get; private set; }
        
        public int Width { get; private set; }
        
        public int Area
        {
            get
            {
                return _area.Value;
            }
        }
    }
