    public class User
    {
       public int Id {get; set;}
       public int SomeProperty {get; set;}
       [ForeignKey("Group")] 
       public int GroupId {get;set;}
       public virtual Group Group { get; set; }
    }
