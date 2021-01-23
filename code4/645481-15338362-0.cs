    public class User
    {
       public int Id {get;set;}
    
       public int Role1Id {get; set;}
    
       [ForeignKey("Role1Id")]
       public Role Role1 {get; set;}
    }
