    private void DrawGrid()
    {
        Graphics graphics = Graphics.FromImage(_grid);
        graphics.Clear(Color.White); 
        for (int x = 0; x < _boardSize; x++) {
            for (int y = 0; y < _boardSize; y++) {
                var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);
                if (_activeBoard[x, y]) {
                    graphics.FillRectangle(Brushes.Black, rect);
                } else {
                    graphics.DrawRectangle(Pens.Black, rect);
                }
            }
        }
        gridPictureBox.Image = _grid;
    }
