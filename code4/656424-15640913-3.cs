    public class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    // elsewhere in your code...
    
    public void SomeFunc(Person person)
    {
         person.FirstName = "Sam";
         person.LastName = "Smith";
    }
