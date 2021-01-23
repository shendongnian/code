    class SomeClass
    {
        private Color? color; // defaults to null
        public Color Color
        {
            get
            {
                if (color == null) return Color.Black;
                else return (Color)color;
            }
            set
            {
                color = value;
            }
        }
    }
