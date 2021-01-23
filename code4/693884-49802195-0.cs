    ExcelWorksheet ws = ...
    
    Int32 maxLength = ws.Dimension.End.Row + 1;
    Int32 maxWidth = ws.Dimension.End.Column + 1;
    // Fetch the entire sheet as one huge range
    ExcelRange cells = ws.Cells[1, 1, maxLength, maxWidth];
    
    // cells.Values now contains a 2 dimensional object array
    // Feel free to stop here
    
    // I wanted a jagged array of type string, so I converted it.
    // Start by converting the 2D array to 1D.
    object[] obj_values = ((object[,]) cells.Value).Cast<object>().ToArray();
    
    // Convert object[] to string[]
    string[] str_values = Array.ConvertAll(obj_values, p => p == null ? "" : p.ToString());
    // Chunk 1D array back into a jagged array and convert nulls to String.Empty
    Int32 j = 0;
    string[][] values = str_values.GroupBy(p => j++ / maxWidth).Select(q => q.ToArray()).ToArray();
    // This was very fast compared to FOR loops!
