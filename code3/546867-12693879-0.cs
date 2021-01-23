      public class PhoneNumber : Entity
      {
        public long PhoneNumberId { get; set; }
    
        [ForeignKey("PersonId")]
        public virtual Person Person {get; set; }
      } 
