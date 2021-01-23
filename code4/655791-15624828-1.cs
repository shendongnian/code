    public class Group  {
    
             public System.Guid Id { get; set; }
             public string Name { get; set; }
             public System.Guid AttrSetId {get;set;}         
             
             [ForeignKey("AttrSetId")]
             public virtual AttrSet AttrSet { get; set; }
     }
