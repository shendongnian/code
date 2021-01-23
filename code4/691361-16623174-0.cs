    public sealed class ColouredSquareCollection
    {
        readonly int _width;
        readonly int _height;
        readonly Color[,] _colours;
        public ColouredSquareCollection(int width, int height)
        {
            _width  = width;
            _height = height;
            _colours = new Color[_width, _height];
            intialiseColours();
        }
        public Color this[int x, int y]
        {
            get { return _colours[x, y]; }
            set { _colours[x, y] = value; }
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }
        void intialiseColours()
        {
            for (int y = 0; y < _height; ++y)
                for (int x = 0; x < _width; ++x)
                    _colours[x, y] = Color.White;
        }
    }
