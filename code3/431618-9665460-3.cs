    private static string[,] Parse(string path, int columnCount, char columnSeparator = ',')
    {
     string[] lines = File.ReadAllLines(path);
    
     string[,] result = new string[lines.Length, columnCount];
     for (int rowIndex = 0; rowIndex < lines.Length; ++rowIndex)
     {
      string[] columns = lines[rowIndex].Split(new char[] { columnSeparator }, columnCount);
    
      for (int columnIndex = 0; columnIndex < columns.Length; ++columnIndex)
       result[rowIndex, columnIndex] = columns[columnIndex];
     }
    
     return result;
    }
