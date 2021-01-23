      pubic class Person
        {
         [Key]
         public string Name {get;set;}
        
         Public PersonPhone HomePhone{get; set;}
         Public PersonPhone CellPhone{get; set;}
        
        }   
        
        public class Phone{
         [Key]
         public int PhoneNumber {get;set;}
        }
        
        pubic class PersonPhone
        {
        [Key]
        public virtual Phone Phone {get;set;}
        [Key]
        public PhoneType PhoneType {get;set;}
        }
        
        public enum PhoneType
        {
        HomePhone,
        CellPhone 
        }
