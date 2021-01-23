    public class Work
    {
       [Key]
       public int id; {get; set;}
    
       [ForeignKey("Member")]
       public int memberId {get; set;}
    
       public virtual Member Member {get; set;}
    }
