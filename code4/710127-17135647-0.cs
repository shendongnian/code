    public class Cell
    { 
        public Cell (int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public bool IsExplored { get; set; }
    }
