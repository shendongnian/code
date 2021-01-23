    static void Main(string[] args)
    {
      var list = Enum.GetValues(typeof(VertebralHeight)).OfType<VertebralHeight>();
      foreach (var vh in list)
      {
        Console.WriteLine("{0} : {1}", vh.ToNameString(), vh.ToHeightValue());
      }
      Console.ReadLine();
    }
