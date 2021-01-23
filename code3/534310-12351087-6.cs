    public class MainViewModel : NotificationObject
    {
        public Person Person { get; set; }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
