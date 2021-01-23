    public interface IFoo
    {
      string Name { get; }
    
      string ToXml();
    
      IFoo Parse(string xml);
    }
    public abstract class AFoo
    {
      public string Name { get; set; }
    
      public string ToXml() { };
    
      public IFoo Parse(string xml) { return AFoo.StaticParse(xml); };
      public static IFoo StaticParse(string xml) { };  // implement one here
    }
