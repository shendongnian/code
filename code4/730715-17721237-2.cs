    public object[,] ReadRange(int aColFrom, int aColTo, int aRowFrom, int aRowTo)
    {
      this.BeginUpdate();
      try
      {
        SpreadsheetGear.IRange oRange = m_ViewLock.Workbook.ActiveWorksheet.Cells[aRowFrom, aColFrom, aRowTo, aColTo];
        object[,] oValues = new object[aRowTo - aRowFrom + 1, aColTo - aColFrom + 1];
        int iRCol = 0;
        for (int iCol = aColFrom; iCol <= aColTo; iCol++)
        {
          int iRRow = 0;
          for (int iRow = aRowFrom; iRow <= aRowTo; iRow++)
          {
            oValues[iRRow, iRCol] = oRange.Cells[iRRow, iRCol].Value;
            iRRow++;
          }
          iRCol++;
        }
        return oValues;
      }
      finally
      {
        this.EndUpdate();
      }
    }
