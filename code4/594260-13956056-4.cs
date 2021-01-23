    public enum Sex
    {
        Male,
        Female
    }
    public class Person
    {
        public string Name { get; private set; }
        public Sex Gender { get; private set; }
 
        public Person(string name, Sex gender)
        {
            Name = name;
            Gender = gender;
        }
    }
