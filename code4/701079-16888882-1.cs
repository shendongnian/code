    Parallel.For(1, D+1 , r =>
    {
      for (int c = 1; c <= D ; c++)
      {
        if (GridA[r, c] != 0)
        {
          int v = GridA[r, c];
          lock(GridB) 
          { 
            GridB[r - 1, c - 1] += v;
            // etc.
          }
        }
      }
    });
