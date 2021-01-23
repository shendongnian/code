        private void InitialiseGameBoard()
        {
            GameBoard = new Tile[_Width, _Height];
            for (var x = 0; x < _Width; x++)
            {
                for (var y = 0; y < _Height; y++)
                {
                    GameBoard[x, y] = new Tile(x, y);
                }
            }
            AllTiles.ToList().ForEach(o => o.FindNeighbours(GameBoard));
            int startX = 0, endX = GameBoard.GetLength(0) - 1;
            int startEndY = GameBoard.GetLength(1) / 2;
            _StartGridPoint = new Point(startX, startEndY);
            _EndGridPoint = new Point(endX, startEndY);
            //GameBoard[startX, startEndY].CanPass = false;
            //GameBoard[endX, startEndY].CanPass = false;
        }
        private void BlockOutTiles()
        {
            GameBoard[2, 5].CanPass = false;
            GameBoard[2, 4].CanPass = false;
            GameBoard[2, 2].CanPass = false;
            GameBoard[3, 2].CanPass = false;
            GameBoard[4, 5].CanPass = false;
            GameBoard[5, 5].CanPass = false;
            GameBoard[5, 3].CanPass = false;
            GameBoard[5, 2].CanPass = false;
        }
        public IEnumerable<Tile> AllTiles
        {
            get
            {
                for (var x = 0; x < _Width; x++)
                    for (var y = 0; y < _Height; y++)
                        yield return GameBoard[x, y];
            }
        }
