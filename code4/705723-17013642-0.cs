    public void CreateMyGrid(Graphics g) 
    {
        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                g.DrawRectangle(pen1, cellSize * c, cellSize * r, cellSize, cellSize);
                Cell newCell = new Cell(rows * columns, new Vector(c, r));
                newCell.rectangle = new Rectangle(cellSize * c,
                    cellSize * r,
                    cellSize,
                    cellSize);
                gridList.Add(newCell);
            }
        }
        foreach (Cell cell in gridList)
        {
            if (cell.positionCR.X == start.X && cell.positionCR.Y == start.Y)
            {
                g.DrawImage(potato, cell.rectangle.X + 1, cell.rectangle.Y + 1);
            }
            if (cell.positionCR.X == goal.X && cell.positionCR.Y == goal.Y)
            {
                g.DrawImage(cake, cell.rectangle.X + 1, cell.rectangle.Y + 1);
            }
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e){
         CreateMyGrid(e.Graphics);
    }
