    public class Button
    {
        public int Width
        {
            get
            {
                return Rectangle.Width;
            }
            set
            {
                Rectangle.Width = value;
            }
        }
        public int Height
        {
            get
            {
                return Rectangle.Height;
            }
            set
            {
                Rectangle.Height = value;
            }
        }
        public int X
        {
            get
            {
                return Rectangle.Left;
            }
            set
            {
                Rectangle.Left = value;
            }
        }
        public int Y
        {
            get
            {
                return Rectangle.Top;
            }
            set
            {
                Rectangle.Top = value;
            }
        }
        public Rectangle Rectangle
        {
            get;
            set;
        }
    }
