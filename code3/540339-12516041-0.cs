    public class Person
    {
        string _initials = "";
        public String FirstName { get; set; }
        public String LastName { get; private set; }
        public String MiddleName { get; private set; }
        public String Initials { get { return _initials; } }
        public String FullName { get { return FirstName + MiddleName + LastName; } }
        public Person(String name)
        {
            string[] names = name.Split(' ');
            if (names.Length != 3)
            {
                throw new ArgumentException("Incorrect format for a person.");
            }
            FirstName = names[2];
            MiddleName= names[1];
            LastName  = names[0];
            _initials = String.Concat(FirstName[0], MiddleName[0], LastName[0]);
        }
    }
