    public class Temp
    {
      public string Name { get; set; }
      public DateTime Start { get; set; }
      public double Value { get; set; }
      public TimeSpan ts { get; set; }
      public double tsMilliseconds { get; set; }
    }
      List<Objects.Temp> ltemp = new List<Objects.Temp>();
      System.Random r = new Random();
      Objects.Temp t = new Objects.Temp();
      t.Name = "One";
      t.Start = DateTime.Now;
      t.Value = r.NextDouble();
      t.ts = DateTime.Today.AddDays(25) - t.Start;
      t.tsMilliseconds = t.ts.TotalMilliseconds;
      ltemp.Add(t);
      t = new Objects.Temp();
      t.Name = "Two";
      t.Start = DateTime.Now;
      t.Value = r.NextDouble();
      t.ts = DateTime.Today.AddDays(15) - t.Start;
      t.tsMilliseconds = t.ts.TotalMilliseconds;
      ltemp.Add(t);
      t = new Objects.Temp();
      t.Name = "Three";
      t.Start = DateTime.Now;
      t.Value = r.NextDouble();
      t.ts = DateTime.Today.AddDays(55) - t.Start;
      t.tsMilliseconds = t.ts.TotalMilliseconds;
      ltemp.Add(t);
