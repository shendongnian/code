    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public Person()
        {
            this.FirstName = null;
            this.LastName = null;
            this.Age = -1;
            this.Grade = -1;
        }
    }
