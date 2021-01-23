    for(int row = 0;row < numRows; row++){
      int total = 0;
        for (int column = 3; column < 27; column++)
        {
              total = total + Convert.ToInt32(this.grid2.Cell(row, column));
        }
      this.grid2.Cell(ROW, 27).Text = total.ToString();
    }
