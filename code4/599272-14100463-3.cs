    public struct ReadOnlySize
    {
        public ReadOnlySize(Size size)
        {
            _size = size;
        }
        private Size _size;
        public float Height 
        {
            get { return  _size.Height; } 
        }
        public float Width
        {
            get { return _size.Width; }
        }
    }
