    class Student : Human 
    {
        private double Grade;
    
        public Student(string FirstName, string LastName, double Grade)
            : base(FirstName, LastName)
        {
            if (Grade < 2 || Grade > 6)
                throw new ArgumentOutOfRangeException("Grade must be between 2 and 6");
    
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
        }
    }
