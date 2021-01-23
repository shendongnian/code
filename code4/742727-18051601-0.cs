    public abstract class Root
    {
      [Key]
      public int RootId { get; set; }
      public string RootProperty { get; set; }
    }
    public class ChildA : Root
    {
     [Required]
     int RootId	
     ForeignKey["RootId"]
     public Root Root {get;set;}	
     public string ChildAProperty { get; set; }
    } 
    public class ChildB : Root {
       [Required]
       int RootId	
       ForeignKey["RootId"]
       public Root Root {get;set;}		
       public string ChildBProperty { get; set; }
     }
    public class SubChildAa : ChildA
    {
      public string SubChildAaProperty { get; set; }
    }
    public class SubChildAb : ChildA
    {
      public string SubChildAbProperty { get; set; }
    }
