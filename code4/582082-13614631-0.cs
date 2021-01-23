    public interface IPhone
    {
        int PhoneID {get;set;}
        string PhoneNumber {get;set;}
    }
    public abstract AbstractPhoneBase : IPhone
    {
        public int PhoneID {get;set;}
        public string PhoneNumber {get;set;}
    }
    
    public CustomerPhone : AbstractPhoneBase
    {
        public int CustomerID {get;set;}
    }
