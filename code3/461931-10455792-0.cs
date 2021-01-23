    string[] src = { "AC1234", "GS3R2C1234", "1234", "A-1234", "AC1234g",
                     "GS3R2C1234g", "1234g", "A-1234g", "999", "GS3R2C9999g" };
    foreach (string before in src)
    {
      string after = Regex.Replace(before, @"\d+(?=\D*$)", 
          m => (Convert.ToInt64(m.Value) + 1).ToString());
      Console.WriteLine("{0} -> {1}", before, after); 
    }
