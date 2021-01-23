    public class Person
    {
        private string name_;
        public Person(string name)
        {
            name_ = name;
        }
        // allow conversion to a string
        public static implicit operator string(Person p)
        {
            return p.name_;
        }
    }
