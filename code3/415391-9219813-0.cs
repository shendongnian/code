    for (i=0; i< dt.Rows.Count ; i++)
    {
      Debug.WriteLine("Start of Row");
      for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++) 
      {
        string val = dt.Rows[i].ItemArray[j].ToString();
        dt.Rows[i].ItemArray[j] = "My New Value";
    
        Debug.WriteLine("val: {0}, new: {1}", val, dt.Rows[i].ItemArray[j].ToString());
      }
    }
