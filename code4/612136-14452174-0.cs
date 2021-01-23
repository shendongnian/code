      pubic class Person
        {
         [Key]
         public string Name {get;set;}
        
         Public List<PersonPhone> PhoneList{get; set;}
        
        }   
        
        public class Phone{
         [Key]
         public int PhoneNumber {get;set;}
        }
        
        pubic class PersonPhone
        {
        public virtual Phone Phone {get;set;}
        public PhoneType PhoneType {get;set;}
        }
        
        public enum PhoneType
        {
        HomePhone,
        CellPhone 
        }
