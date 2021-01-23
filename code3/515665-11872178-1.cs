    public List<Cell> GetCellIntersections (Cell cell1, Cell cell2)
    {
        Cell c1 = null;
        Cell c2 = null;
        List<Cell> cells = null;
        System.Numerics.BigInteger delta = 0;
        System.Numerics.BigInteger deltaHalf = 0;
        System.Numerics.BigInteger width = 0;
        System.Numerics.BigInteger height = 0;
        cells = new List<Cell>();
        // Sorting on y reduces conditions from 8 to 4.
        if (cell1.Y < cell2.Y)
        {
            c1 = cell1;
            c2 = cell2;
        }
        else
        {
            c1 = cell2;
            c2 = cell1;
        }
        if ((c1.X != c2.X) && (c1.Y != c2.Y))
        {
            width = System.Numerics.BigInteger.Abs(c2.X - c1.X);
            height = System.Numerics.BigInteger.Abs(c2.Y - c1.Y);
            delta = System.Numerics.BigInteger.Abs(height - width);
            deltaHalf = System.Numerics.BigInteger.Divide(delta, 2);
            if ((c1.X < c2.X) && (c1.Y < c2.Y))
            {
                if (width < height)
                {
                    cells.Add(new Cell(this, c1.X - deltaHalf, c1.Y + deltaHalf));
                    cells.Add(new Cell(this, c2.X + deltaHalf, c2.Y - deltaHalf));
                }
                else
                {
                    cells.Add(new Cell(this, c1.X + deltaHalf, c1.Y - deltaHalf));
                    cells.Add(new Cell(this, c2.X - deltaHalf, c2.Y + deltaHalf));
                }
            }
            else
            {
                if (width < height)
                {
                    cells.Add(new Cell(this, c1.X + deltaHalf, c1.Y + deltaHalf));
                    cells.Add(new Cell(this, c2.X - deltaHalf, c2.Y - deltaHalf));
                }
                else
                {
                    cells.Add(new Cell(this, c1.X - deltaHalf, c1.Y - deltaHalf));
                    cells.Add(new Cell(this, c2.X + deltaHalf, c2.Y + deltaHalf));
                }
            }
        }
        return (cells);
    }
