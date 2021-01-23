    while (success && x < size)
    {
      if (_grid[location] == 0)
      {
        coords[x++] = location;
        location += increment;
    
        if (location >= GRID_SIZE)
        {
            success = false;
        }
        if (x > 0 && (location % GRID_LENGTH == 0)) // Right edge is out of bounds
        {
            success = false;
        }
        else
        {
            success = true;
        }
      }
      x++;
    }
