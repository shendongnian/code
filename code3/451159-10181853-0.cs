    Worksheet ws = new Worksheet();
    Columns columns = new Columns();
    columns.Append(CreateColumnData(1, 1, 14.87));
    ws.append(columns);
  
    private static Column CreateColumnData(UInt32 StartColumnIndex, UInt32 EndColumnIndex, double ColumnWidth)
        {
            Column column;
            column = new Column();
            column.Min = StartColumnIndex;
            column.Max = EndColumnIndex;
            column.Width = ColumnWidth;
            column.CustomWidth = true;
            return column;
        }
