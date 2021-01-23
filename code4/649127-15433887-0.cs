    public Student(string firstName, string lastName, double grade)
        : base(firstName, lastName)
    {
        #region Contract
        if (grade < 2.00 || grade > 6.00)
            throw new ArgumentOutOfRangeException("grade");
        #endregion
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Grade = grade;
    }
