    public string TempFilePath{get;set;}
    public void WriteTempData(string data)
    {
      using(sw = new StreamWriter(TempFilePath, true))
        sw.Write(data);
    }
