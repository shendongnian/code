    class Student : Human 
    {
        private double Grade;
        public Student(string FirstName, string LastName, double Grade)
            : base(FirstName, LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
            if(Grade >= 2 and Grade <= 6){
                throw new Exception("Incorrect grade input");
        }
    }
