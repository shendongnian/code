    public string[,] ReadArray(int SheetNumber)
    {
      worksheet = (Excel.Worksheet)sheets.get_Item(SheetNumber);
      Excel.Range range = worksheet.UsedRange;
      //Get array, use range values. Not always correct, esp if user has deleted data. Ignore null values
      Object[,] arr = range.Cells.Value;
      string[,] output = new string[arr.GetLength(0), arr.GetLength(1)];
      for (int i = 0; i < arr.GetLength(0); i++)
      {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
          //If nothing in the cell, write a blank
          if (arr[i + 1, j + 1] == null)
          {
            output[i, j] = "";
            continue;
          }
          //else, write the output
          output[i, j] = arr[i + 1, j + 1].ToString();
        }
      }
      if (range != null)
        Marshal.ReleaseComObject(range);
      if (worksheet != null)
        Marshal.ReleaseComObject(worksheet);
      return output;
    }
