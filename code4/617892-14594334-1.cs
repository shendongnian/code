    public interface IBed
    {
        BedSize BedSize { get; set; }
    }
    public enum BedSize
    {
       Small,
       Medium,
       Large
    }
    
    public class House : IBed
    {
      public BedSize BedSize { get; set; }
    }
  
