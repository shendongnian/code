    public class Parent
    {
       public string FirstName {get; set;}
        public string LastName {get; set;}
        public string City {get; set;}
    }
    public class Child : Parent
    {
        public string PhoneNumber {get; set;}
        public string MobileNumber {get; set;}
        public Child (Parent parentToCopy)
        {
            this.FirstName = parentToCopy.FirstName;
            this.LastName = parentToCopy.LastName;
            this.City = parentToCopy.City;
            this.PhoneNumber = string.Empty; // Or any other default.
            this.MobileNumber = string.Empty;
        } 
    }
