    public class Person
     {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Image myImage { get; set; }
        public Person()
        {
        }
        public Person(string firstName, string lastName, string imagePath)
        {
           this.fName = firstName;
           this.lName = lastName;
           this.myImage = Image.FromFile(imagePath);
        }
    }
