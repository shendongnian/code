    public class Class
    {
      [Key]
      public int ClassId { get; set; }
      public string Data { get; set; }
    }
    public class Classes
    {
      public virtual List<Class> Classes { get; set; }
    }
