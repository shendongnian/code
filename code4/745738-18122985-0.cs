    class Grid
    {
        public Grid(int width, int length) {
            coordinates = new List<Coordinate>();
            int size = width * length;
            for (int i = 1; i < width + 1; i++) {
                for (int k = 1; k < length + 1; k++) {
                    coordinates.Add(new Coordinate(k,i));
                }
            }
        }
        List<Coordinate> coordinates;
        int width { get; set; }
        int length { get; set; }
        public int accessCoordinate(int x,int y) {
            return coordinates.Where(coord => coord.x == x && coord.y == y)
                              .FirstOrDefault().storedValue;
        }
        public void assignValue(int x, int y,int value) {
            coordinates.Where(coord => coord.x == x && coord.y == y)
                       .FirstOrDefault().storedValue = value;
        }
    }
    class Coordinate
    {
        public Coordinate(int _x, int _y) {
            x = _x;
            y = _y;
        }
        public int x { get; set; }
        public int y { get; set; }
        public int storedValue { get; set; }
    }
