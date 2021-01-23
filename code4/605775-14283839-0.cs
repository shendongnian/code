    using (FileStream fs = new FileStream("", FileMode.Open))
    {
      using (StreamReader rdr = new StreamReader(fs))
      {
        while (!rdr.EndOfStream)
        {
          DoSomethingWith(rdr.ReadLine().Split('|')));
        }
      }
    }
    void DoSomethingWith(String[] argColumns)
    {
      // on y va
    }
