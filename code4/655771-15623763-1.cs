    public interface INamed
    {
       string Name { get; }
    }
    public class RiverAdapter : INamed
    {
      private River _river;
      public string Name { get { return _river.Name; } }
    }
    public class CityAdapter : INamed
    {
      private River _city;
      public string Name { get { return _city.Name; } }
    }
