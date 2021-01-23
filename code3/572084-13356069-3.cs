    private int[][] ConvertToMapArray(String data) 
    {
        return data.Split(new [] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                   .Select(row => row.Split(',')
                                     .Select(item => {int i; Int32.TryParse(item, out i); return i;})
                                     .ToArray())
                   .ToArray();
    }
