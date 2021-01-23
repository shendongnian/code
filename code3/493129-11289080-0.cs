    public abstract class User
    {
        public string Username{get;set;}
        public string Password{get;set;}
        public string Email{get;set;}
        public string Mobile{get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Student : User
    {
        //other properties and methods
    }
    public class Staff : User
    {
        //other properties and methods
    }
