    public class Person {
        public Person(string firstName, string secondName) {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Comments = String.Empty;
        }
        public Person(string firstName, string secondName, string comments)
            : this(firstName, secondName) {
                this.Comments = comments;
        }
        public bool Selected
        {
            get;
            set;
        }
        public bool Blocked
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string SecondName
        {
            get;
            set;
        }
        public string Comments
        {
            get;
            set;
        }
    }
