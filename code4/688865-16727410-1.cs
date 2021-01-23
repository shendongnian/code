    class SomeClass
    {
        private Color? _color; // defaults to null
        public Color Color
        {
            get { retrun _color ?? Color.Black; }
            set { _color = value; }
        }
        public bool ColorChanged
        {
            get { return _color != null; }
        }
    }
