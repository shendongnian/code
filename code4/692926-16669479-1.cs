    for(int c = 0; c < totalColumns; c++)
    {
      for(int r = 0; r < totalRows; r++)
      {
        colTotal[c] += numbers[r * totalColumns + c];
      }
    }
