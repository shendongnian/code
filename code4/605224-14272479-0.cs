    public class BProxy 
    {
         [Key]
         public int Id {get; set;}
         [Required]
         public int EntityBId {get; set;}
         public virtual EntityB {get; set;}
         [Required]
         public int EntityAId {get; set;}
         public virtual EntityA {get; set;}
    }
