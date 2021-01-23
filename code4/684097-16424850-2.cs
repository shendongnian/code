    public class Connect4Board
    {
        private Box[,] _boxes = new Box[7, 6];
        
        public Connect4Board()
        {
            for(int i = 0; i<7; i++)
            {
                for(int j = 0; j<6; j++)
                {
                    // Notice how you're not changing a color, but assigning the location
                    _boxes[i,j] = Box.Empty;
                }
            }
        }
    
        public void DropPieceAt(int column, bool redPiece)
        {
            // Modifications to the top empty location in the given column.
        }        
    
        public Box GetBoxAt(int x, int y)
        {
            return _boxes[x, y];
        }
    }
    
    public class Box
    {
        public bool IsRed { get; private set; }
        public bool IsBlack { get; private set; }
        public bool IsEmpty { get; private set; }
    
        private Box() {}
    
        public static readonly Box Red = new Box{IsRed = true};
        public static readonly Box Black = new Box{IsBlack = true};
        public static readonly Box Empty = new Box{IsEmpty = true};
    }
