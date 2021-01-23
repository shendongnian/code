    class Student : Human 
    {
        private double Grade;
    
        public Student(string FirstName, string LastName, double Grade)
            : base(FirstName, LastName)
        {
            if (Grade >= 2 && Grade <= 6 ) { 
              throw new ArgumentOutOfRangeException();
            }
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
        }
    }
