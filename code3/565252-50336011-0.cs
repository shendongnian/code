     class Person
     {
        private string FirstName;
        private string LastName;
        private string EmailAddress;
        private DateTime DateOfBirth;
        public Person(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
            
        }
        }
    class Employee : Person
    {
        private double Salary { get; set; } = 0;
        public Employee(string firstName, string lastName, string emailAddress, DateTime dateOfBirth,double salary)
            :base(firstName,lastName,emailAddress,dateOfBirth)// used to pass value to parent constructor and it is mandatory if parent doesn't have the no-argument constructor.
        {
            Salary = salary;
        }
    }
