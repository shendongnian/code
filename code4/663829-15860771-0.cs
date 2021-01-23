    public class Person
    {
        public int Age { get; set; }
        public MaritalStatus MaritialStatus { get; set; }
        public Gender Gender { get; set; }
        public int District { get; set; }
    }
    public enum MaritalStatus
    {
        Single, Married
    }
    public enum Gender
    {
        Mail, Femail
    }
