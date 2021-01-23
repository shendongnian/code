    public class Person
    {
        [key]
        public string name {get;set;}
    
        public virtual ICollection<Phone> Phones {get;set;}
    }
    
    public class Phone
    {
        [key]
        public int PhoneNumber {get;set;}
    
        public int PhoneTypeId {get;set;}
        public virtual PhoneType PhoneType {get;set;}
    }
    
    public class PhoneType
    {
        [key]
        public int PhoneTypeId {get;set;}
        public string PhoneTypeDescription {get;set}
    }
