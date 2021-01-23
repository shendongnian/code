    private int[][] ConvertToMapArray(String arrayData) 
    {
        var rowDelimiter = new [] {'|'};
        return arrayData.Split(rowDelimiter, StringSplitOptions.RemoveEmptyEntries)
                        .Select(row => ConvertToMapRow(row))
                        .ToArray();
    }
    private int[] ConvertToMapRow(String rowData) 
    {
        return row.Split(',')
                  .Select(item => 
                      {
                          int i; 
                          Int32.TryParse(item, out i); 
                          return i;
                      })
                  .ToArray();
    }
