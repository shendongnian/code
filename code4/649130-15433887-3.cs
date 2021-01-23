    using System.Diagnotistics.Contracts;
    public Student(string firstName, string lastName, double grade)
        : base(firstName, lastName)
    {
        #region Contract
        Contract.Requires<ArgumentOutOfRangeException>(grade >= 2.00);
        Contract.Requires<ArgumentOutOfRangeException>(grade <= 6.00);
        #endregion
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Grade = grade;
    }
