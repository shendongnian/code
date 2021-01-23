    class Person
    {
        private string FirstName;
        private string LastName;
        private string EmailAddress;
        private DateTime DateOfBirth;
        public Person()
        {
            // some important intialization's to be done  
            
        }
        public Person(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
            
        }
        }
    class PermanentEmployee : Person
    {
        public double HRA { get; set; }
        public double DA { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }
        public double TotalPay { get; set; }
        public PermanentEmployee(double hRA, double dA, double tax, double netPay, double totalPay) : base();
        {
            HRA = hRA;
            DA = dA;
            Tax = tax;
            NetPay = netPay;
            TotalPay = totalPay;
        }
    }
