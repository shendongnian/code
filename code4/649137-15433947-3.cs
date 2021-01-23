    class Student : Human  {
        private double Grade;
    
        public Student(string FirstName, string LastName, double Grade)
            : base(FirstName, LastName)
        {
            System.Diagnotistics.Contracts.Contract.Requires<ArgumentOutOfRangeException>(Grade >= 2 && Grade <= 6);
    
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
        }
    }
