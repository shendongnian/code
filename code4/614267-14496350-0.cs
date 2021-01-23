    public struct Coordinates
    {
        public int X { get; set; }
        public int y { get; set; }
    }
    
    public static Coordinates Location(int p_1, int p_2, int p_3, int p_4) 
    {
        int  XLocation = p_2 - p_1;
        int YLocation = p_4-p_3;
    
        Coordinates coord = new Coordinates();
        coord.X = XLocation;
        coord.Y = YLocation;
        return coord;
    }
