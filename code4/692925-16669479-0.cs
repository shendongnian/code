    for(int r = 0; r < totalRows; r++)
    {
      for(int c = 0; c < totalColumns; c++)
      {
        rowTotal[r] += numbers[r * totalColumns + c];
      }
    }
