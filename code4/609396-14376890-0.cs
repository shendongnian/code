    foreach (DataRow row in myTopTenData.Rows)
    {
         Console.WriteLine();
         for(int x = 0; x < myTopTenData.Columns.Count; x++)
         {
              Console.Write(row[x].ToString() + " ");
         }
    }
