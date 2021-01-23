    public class RiverAdapter : INamable
    {
      private River _river;
      public string Name { get { return _river.Name; } }
    }
    public class CityAdapter : INamable
    {
      private River _city;
      public string Name { get { return _city.Name; } }
    }
