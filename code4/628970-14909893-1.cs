    string FirstColumn = GetColumnName(GetFirstCellReference(RangeReference));
    string LastColumn = GetColumnName(GetLastCellReference(RangeReference));
    uint FirstRow = GetRowNumber(GetFirstCellReference(RangeReference));
    uint LastRow = GetRowNumber(GetLastCellReference(RangeReference));
    List<string> Result = new List<string>();
    for (uint row = FirstRow; row <= LastRow; row++)
    {
       for (ulong column = ColumnsInNumber[FirstColumn]; column <= ColumnsInNumber[LastColumn]; column++)
       {
         string ColumnName = ColumnsInNumber.Where(kv => kv.Value == column).FirstOrDefault().Key;
         Result.Add(string.Format("{0}{1}", ColumnName, row));
       }
    }
