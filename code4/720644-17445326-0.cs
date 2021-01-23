     public class Person
     {
        public string fName { get; set; }
        public string lName { get; set; }
        public Image image { get; set; }
        public Person()
        {
        }
    
        public Person(string firstName, string lastName, Image image)
        {
            this.fName = firstName;
            this.lName = lastName;
            this.image = image;
        }
     }
