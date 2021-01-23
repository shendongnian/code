    public abstract class Entity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
    [Table("Person")]
    public class Person : Entity
    {
       public string FirstName {get ;set;}
       public string LastName {get ;set;}
    } 
