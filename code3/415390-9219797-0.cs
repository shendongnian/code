    foreach (DataRow row in dt.Rows)
    {
      Debug.WriteLine("Start of Row");
      for (int i = 0; i < row.ItemArray.Length; i++) 
      {
        string val = row[i].ToString();
        row[i] = "My New Value";
    
        Debug.WriteLine("val: {0}, new: {1}", val, row[i].ToString());
      }
    }
