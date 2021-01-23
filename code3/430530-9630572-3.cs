    public static List<int> Divide3Columns(int total, int column)
    {
      int startIndex = 0;
      int endIndex = 0;
      int pageSize = total / 3;
      
      if (total % 3 == 0)
      {
        startIndex = column * pageSize;
        endIndex = (column + 1) * pageSize - 1;
      }
      
      if (total % 3 == 1)
      {
        if (column == 0)
        {
          startIndex = 0;
          endIndex = pageSize; //pageSize + 1 elements;
        }
        else
        {
          startIndex = column * pageSize + 1;
          endIndex = (column + 1) * pageSize;
        }
      }
      
      if (total % 3 == 2)
      {
        if (column == 2)
        {
          startIndex = 2 * pageSize + 2;
          endIndex = 3 * pageSize + 1; //same as total - 1;
        }
        else
        {
          startIndex = column * (pageSize + 1);
          endIndex = (column + 1) * pageSize + column;
        }
      }
      List<int> result = new List<int>();
      for (int i = startIndex; i <= endIndex; i++)
      {
        result.Add(i);
      }
      return result;
    }
