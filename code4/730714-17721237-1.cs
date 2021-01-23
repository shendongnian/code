    /// <summary>
    /// Reads the vertical array from the specified cell
    /// </summary>
    /// <param name="aRow"></param>
    /// <param name="aColumn"></param>
    /// <returns></returns>
    public int[] ReadArrayInt(int aRow, int aColumn)
    {
      int wNbValues = this.GetNumberConsecValues(aRow, aColumn);
      if (wNbValues == 0)
         return null;
      int[] wArr = new int[wNbValues];
      for (int iRow = 0; iRow < wNbValues; iRow++)
      {
        wArr[iRow] = Convert.ToInt32(this[aRow + iRow, aColumn]);
      }
      return wArr;
    }
