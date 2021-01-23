    foreach (DataRow r in ds.Tables[0].Rows)
    {
       for(int x = 0; x < r.ItemArray.Length; x++)
           Console.WriteLine(r.ItemArray[x].ToString());
       Console.WriteLine();    
    }
