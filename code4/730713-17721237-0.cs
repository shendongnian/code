    /// <summary>
    /// gets the number of consecutive (without any empty cell) values vertically
    /// </summary>
    /// <param name="aRow"></param>
    /// <param name="aColumn"></param>
    /// <returns></returns>
    public int GetNumberConsecValues(int aRow, int aColumn)
    {
       int wCount = 0;
       while (this[aRow + wCount, aColumn] != null)
       {
         wCount++;
       }
       return wCount;
    }
