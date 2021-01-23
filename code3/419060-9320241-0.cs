    public class Rectangle
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException();
            Width = width;
            Height = height;
        }
    }
    public class Square : Rectangle
    {
        public int Size
        {
            get
            {
                return Width;
            }
        }
        public Square(int size)
            : base(size, size)
        {
        }
    }
