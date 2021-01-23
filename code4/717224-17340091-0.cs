    List<List<String>> dataList = new List<List<string>>();
    //...
    using (StreamWriter writer = new StreamWriter("file.csv"))
    {
        dataList.ForEach(line =>
        {
            line.ForEach(cell =>
            {
                writer.Write(cell.Contains("\"") ? cell.Replace("\"", "\\\"") : cell);
            });
            writer.WriteLine();
        });
    }
