    public struct Coordinates
    {
        public readonly int x;
        public readonly int y;
        public Coordinates (int _x, int _y) 
        {
            x = _x;
            y = _y;
        }
    }
    
    public static Coordinates Location(int p_1, int p_2, int p_3, int p_4) 
    {
        return new Coordinates(p_2 - p_1, p_4 - p_3);
    }
