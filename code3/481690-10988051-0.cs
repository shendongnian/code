    class Grid
    {
        readonly int _rowCount;
        readonly int _columnCount;
        // Insert data for master list of obstructed cells
        // or master list of unobstructed cells
        public Node GetNode(int row, int column)
        {
            if (IsOnGrid(row, column) && !IsObstructed(row, column))
            {
                return new Node(this, row, column);
            }
            return null;
        }
        private bool IsOnGrid(int row, int column)
        {
            return row >= 0 && row < _rowCount && column >= 0 && column < _columnCount;
        }
        private bool IsObstructed(int row, int column)
        {
            // Insert code to check whether specified row and column is obstructed
        }
    }
    class Node : IHasNeighbours<Node>
    {
        readonly Grid _grid;
        readonly int _row;
        readonly int _column;
        public Node(Grid grid, int row, int column)
        {
            _grid = grid;
            _row = row;
            _column = column;
        }
        public Node Up
        {
            get
            {
                return _grid.GetNode(_row - 1, _column);
            }
        }
        public Node Down
        {
            get
            {
                return _grid.GetNode(_row + 1,_column);
            }
        }
        public Node Left
        {
            get
            {
                return _grid.GetNode(_row, _column - 1);
            }
        }
        public Node Right
        {
            get
            {
                return _grid.GetNode(_row, _column + 1);
            }
        }
        public IEnumerable<Node> Neighbours
        {
            get
            {
                Node[] neighbors = new Node[] {Up, Down, Left, Right};
                foreach (Node neighbor in neighbors)
                {
                    if (neighbor != null)
                    {
                        yield return neighbor;
                    }
                }
            }
        }
    }
