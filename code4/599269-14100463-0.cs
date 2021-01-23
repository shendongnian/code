    public class MySize
    {
        public MySize(float height, float width)
        {
            Height = height;
            Width = width;
        }
        public float Height { get; set; }
        public float Width { get; set; }
        public MySize GetCopy()
        {
            return (MySize)MemberwiseClone();
        }
    }
