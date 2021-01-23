    class Size 
    {
        public int Width { get; set; }
        public int Height { get; set; }
     
        public Size(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }
        public static Size operator *(Size s, int n)
        {
            return new Size(s.Width * n, s.Height * n);
        }
    }
