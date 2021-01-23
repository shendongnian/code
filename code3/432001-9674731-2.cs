    private int[,] LoadData(string inputFilePath)
    {
      int[,] data = null;
      if (File.Exists(inputFilePath))
      {
        Dictionary<string, int> counts = GetRowAndColumnCounts(inputFilePath);
        int rowCount = counts["row_count"];
        int columnCount = counts["column_count"];
        data = new int[rowCount, columnCount];
        using (StreamReader sr = File.OpenText(inputFilePath))
        {
          string s = "";
          string[] split = null;
          for (int i = 0; (s = sr.ReadLine()) != null; i++)
          {
            split = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < columnCount; j++)
            {
              data[i, j] = int.Parse(split[j]);
            }
          }
        }
      }
      else
      {
        throw new FileDoesNotExistException("Input file does not exist");
      }
      return data;
    }
    private Dictionary<string, int> GetRowAndColumnCounts(string inputFilePath)
    {
      int rowCount = 0;
      int columnCount = 0;
      if (File.Exists(inputFilePath))
      {
        using (StreamReader sr = File.OpenText(inputFilePath))
        {
          string[] split = null;
          int lineCount = 0;
          for (string s = sr.ReadLine(); s != null; s = sr.ReadLine())
          {
            split = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (columnCount == 0)
            {
              columnCount = split.Length;
            }
            lineCount++;
          }
          rowCount = lineCount;
        }
        if (rowCount == 0 || columnCount == 0)
        {
          throw new FileEmptyException("No input data");
        }
      }
      else
      {
        throw new FileDoesNotExistException("Input file does not exist");
      }
      Dictionary<string, int> counts = new Dictionary<string, int>();
      counts.Add("row_count", rowCount);
      counts.Add("column_count", columnCount);
      return counts;
    }
