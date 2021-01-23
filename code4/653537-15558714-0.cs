    public void doStuff()
    {
      AverageValues AVS = new AverageValues();
      AVS.Bull = "Woof";
      string path = "C:\\users\\kjenks11\\Averages.txt";
      using (var NewFile = File.Create(path))
      {
        using (var writeIt = new StreamWriter(NewFile))
        {
          List<AverageValues> AV = new List<AverageValues> {AVS};
          foreach (var value in AV)
          {
            writeIt.Write(value.Bull);
          }
        }
      }
    }
