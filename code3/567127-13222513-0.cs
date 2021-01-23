    public class MyClass
    {
      public DateTime Time { get; set; }
      public string Name { get; set; }
      public override string ToString()
      {
        return string.Format("Time = {0}. Name = {1}.", Time, Name);
      }
    }
