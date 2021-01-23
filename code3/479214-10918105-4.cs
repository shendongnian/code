    public class rectangle()
    {
        public rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }
    
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Area { get; private set; }
    
        public void resize(int heightOffset, int widthOffset)
        {
            Height += heightOffset;
            Width += widthOffset;
    
            RefreshArea();
        }
    
        private void RefreshArea() 
        {
            Area = Height * Width;
        }
    }
