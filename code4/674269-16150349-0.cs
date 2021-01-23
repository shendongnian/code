    class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string fName, string lName) {
            FirstName = fName;
            LastName = lName;
        }
        public override void ToString() {
            return FirstName + " " + LastName;
        }
    }
    // in your main method
    Person p = new Person("Albert", "Einstein");
    Console.WriteLine(p.ToString());
