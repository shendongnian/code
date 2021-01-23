      public class Person : Entity
      {
        [Key]
        public long PersonId { get; set; }
        public virtual PhoneNumber PhoneNumber {get; set; }
      }
      
      public class PhoneNumber : Entity
      {
        [Key, ForeignKey("Person")]
        public long PhoneNumberId { get; set; }
    
        
        public virtual Person Person {get; set; }
      } 
