    public class Tile : SpacialObject, IHasNeighbours<Tile>
    {
        public Tile(int x, int y)
            : base(x, y)
        {
            CanPass = true;
        }
        public bool CanPass { get; set; }
        public Point GetLocation(int gridSize)
        {
            return new Point(this.X * gridSize, this.Y * gridSize);
        }
        public IEnumerable<Tile> AllNeighbours { get; set; }
        public IEnumerable<Tile> Neighbours { get { return AllNeighbours.Where(o => o.CanPass); } }
        public void FindNeighbours(Tile[,] gameBoard)
        {
            var neighbours = new List<Tile>();
            var possibleExits = X % 2 == 0 ? EvenNeighbours : OddNeighbours;
            possibleExits = GetNeighbours;
            foreach (var vector in possibleExits)
            {
                var neighbourX = X + vector.X;
                var neighbourY = Y + vector.Y;
                if (neighbourX >= 0 && neighbourX < gameBoard.GetLength(0) && neighbourY >= 0 && neighbourY < gameBoard.GetLength(1))
                    neighbours.Add(gameBoard[neighbourX, neighbourY]);
            }
            AllNeighbours = neighbours;
        }
        public static List<Point> GetNeighbours
        {
            get
            {
                return new List<Point>
                {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(0, -1),
                    new Point(-1, 0),
                };
            }
        }
        public static List<Point> EvenNeighbours
        {
            get
            {
                return new List<Point>
                {
                    new Point(0, 1),
                    new Point(1, 1),
                    new Point(1, 0),
                    new Point(0, -1),
                    new Point(-1, 0),
                    new Point(-1, 1),
                };
            }
        }
        public static List<Point> OddNeighbours
        {
            get
            {
                return new List<Point>
                {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(1, -1),
                    new Point(0, -1),
                    new Point(-1, 0),
                    new Point(-1, -1),
                };
            }
        }
    }
