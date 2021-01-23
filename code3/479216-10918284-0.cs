    class Rectangle
    {
        int _height;
        public int height { get { return _height; } set { _height = value; _area = null; }}
        int _width;
        public int width { get { return _width; } set { _width = value; _area = null; } }
        int? _area;
        public int area
        {
            get
            {
                if(!_area.HasValue)
                    _area = _width * _height;
                return _area.Value;
            }
        }
    }
