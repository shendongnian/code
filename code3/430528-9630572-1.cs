    int startIndex;
    int endIndex;
    int pageSize = total / 3;
    if (total % 3 == 0)
    {
      startIndex = column * pageSize;
      endIndex = column * (pageSize + 1) - 1;
    }
    if (total % 3 == 1)
    {
      if (column = 0)
      {
         startIndex = 0;
         endIndex = pageSize; //pageSize + 1 elements;
      }
      else
      {
         startIndex = column * pageSize + 1;
         endIndex = column * (pageSize + 1);
      }
    }
    if (total % 3 == 2)
    {
      if (column = 2)
      {
         startIndex = 2 * pageSize + 2;
         endIndex = 3 * pagesize + 1; //same as total - 1;
      }
      else
      {
         startIndex = column * (pageSize + 1);
         endIndex = (column + 1) * pageSize + column;
      }
    }
