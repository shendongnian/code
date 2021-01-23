    static void Main(string[] args)
    {
      // Read sample data from CSV file
      List<List<string>> list = new List<List<string>>();
      using (CsvFileReader reader = new CsvFileReader(@"C:\\path_to_file\file.csv"))
      {
        CsvRow row = new CsvRow();
        while (reader.ReadRow(row))
        {
          List<string> rowList = new List<string>();
          foreach (string s in row)
          {
            //Console.Write(s);
            //Console.Write(" ");
            rowList.Add(s);
          }
          list.Add(rowList);
          //Console.WriteLine();
        }
      }
      foreach (List<string> rowList in list)
      {
         foreach (string cellData in rowList)
         {
            Console.Write(cellData + "\t");
         }
         Console.WriteLine();
      }
      Console.ReadLine();
    }
