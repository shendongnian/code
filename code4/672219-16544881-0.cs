        private Tile[,,] tiles;
        public Cube(int size)
        {
            tiles = new Tile[size, size, 6];
            // initialize.
            for (var side = 0; side < 6; side++)
            {
                for (var x = 0; x < size; x++)
                {
                    for (var y = 0; y < size; y++)
                    {
                        tiles[x, y, side] = new Tile(x, y, side);
                    }
                }
            }
            // set directions & neighbors
            for (var side = 0; side < 6; side++)
            {
                for (var x = 0; x < size; x++)
                {
                    for (var y = 0; y < size; y++)
                    {
                        // todo: implement.
                    }
                }
            }
        }
        public Tile this[int x, int y, int side]
        {
            get
            {
                return tiles[x, y, side];
            }
        }
    }
    public class Tile
    {
        private Dictionary<DirectionType, Tile> directions = new Dictionary<DirectionType, Tile>();
        private Tile[] neighbors = new Tile[4];
        public Tile(int x, int y, int side)
        {
            this.X = x;
            this.Y = y;
            this.Side = side;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Side { get; private set; }
        public Tile this[DirectionType dir]
        {
            get
            {
                return directions[dir];
            }
        }
        public Tile[] Neighbors { get { return neighbors; } }
    }
    public enum DirectionType
    {
        // delta: +1, 0
        e,
        // delta: 0, +1
        n,
        // delta: -1, 0
        w,
        // delta: 0, -1
        s,
        // delta: 0, 0
        X
    }
