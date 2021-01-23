    public class AttrSet {
    
      public System.Guid Id { get; set; }
      public string Name { get; set; }
    
      [Required, ForeignKey("MyGroup")]
      public int GroupID { get; set; }
    
      public virtual Group MyGroup { get; set; } 
    }
