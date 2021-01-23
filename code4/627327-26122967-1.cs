    [Serializable]
    [XmlInclude(typeof(cat))]
    [XmlInclude(typeof(fish))]
    class animals
    {
         ....
    }
    public class cat:animals
    {
      public string size { get; set; }
      public string furColor { get; set; }
    }
    public class fish:animals
    {
      public string size { get; set; }
      public string scaleColor { get; set; }
    }
