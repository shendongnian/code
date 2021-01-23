    public class SudokoSolver
    {
        private readonly Grid _grid;
        public SudokoSolver(Grid grid)
        {
            _grid = grid;
        }
        public int?[,] SolvePuzzle()
        {
            Solve();
            return _grid.Data;
        }
        private bool Solve()
        {
            int row, col;
            if (!_grid.FindUnassignedLoc(out row, out col))
            {
                return true;
            }
            for (int num = 1; num <= 9; num++)
            {
                if (_grid.NoConflicts(row, col, num))
                {
                    _grid.Assign(row, col, num);
                    if (Solve())
                    {
                        return true;
                    }
                    _grid.Unassign(row, col);
                }
            }
            return false;
        }
        public int?[,] Data
        {
            get { return _grid.Data; }
        }
    }
    public class Grid
    {
        public int?[,] Data { get; private set; }
        private int _curC = 0;
        private int _curR = 0;
        public Grid(int?[,] data)
        {
            Data = data ?? new int?[9,9];
        }
        public bool FindUnassignedLoc(out int row, out int col)
        {
            while (Data[_curR, _curC].HasValue)
            {
                _curC++;
                if (_curC/9 > 0)
                {
                    _curR++;
                }
                _curC %= 9;
                
                if (_curR > 8)
                {
                    row = -1;
                    col = -1;
                    return false;
                }
            }
            row = _curR;
            col = _curC;
            return true;
        }
        public bool NoConflicts(int row, int col, int num)
        {
            for (int r = 0; r < 9; ++r)
            {
                if (Data[r, col] == num)
                {
                    return false;
                }
            }
            for (int c = 0; c < 9; c++)
            {
                if (Data[row, c] == num)
                {
                    return false;
                }
            }
            int fromC = 3 * (col/3);
            int fromR = 3 * (row / 3);
            for (int c = fromC; c < fromC + 3; c++)
            {
                for (int r = fromR; r < fromR + 3; r++)
                {
                    if (Data[r, c] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void Assign(int row, int col, int num)
        {
            Data[row, col] = num;
        }
        public void Unassign(int row, int col)
        {
            Data[row, col] = null;
            _curC = col;
            _curR = row;
        }
    }
