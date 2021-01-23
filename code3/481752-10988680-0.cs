    public List<Objects.Temp> GetTemp()
    {
      List<Objects.Temp> ltemp = new List<Objects.Temp>();
      System.Random r = new Random();
      Objects.Temp t = new Objects.Temp();
      t.Name = "One";
      t.start = DateTime.Now;
      t.Value = r.NextDouble();
      t.ts = DateTime.Today.AddDays(25) - t.start;
      t.tsDays = t.ts.Days;
      ltemp.Add(t);
      t = new Objects.Temp();
      t.Name = "Two";
      t.start = DateTime.Now;
      t.Value = r.NextDouble();
      t.ts = DateTime.Today.AddDays(15) - t.start;
      t.tsDays = t.ts.Days;
      ltemp.Add(t);
      t = new Objects.Temp();
      t.Name = "Three";
      t.start = DateTime.Now;
      t.Value = r.NextDouble();
      t.ts = DateTime.Today.AddDays(55) - t.start;
      t.tsDays = t.ts.Days;
      ltemp.Add(t);
      return ltemp;
    }
