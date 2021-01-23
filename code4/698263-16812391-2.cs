    int total = 0;
    for (int B = 3; B < 27; B++)
    {
          total = total + Convert.ToInt32(this.grid2.Cell(0, B));
    }
    
    this.grid2.Cell(0, 27).Text = total.ToString();
