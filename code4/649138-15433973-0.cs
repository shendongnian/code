    public Student(string firstName, string lastName, decimal grade)
    {
        Contract.Requires(grade >= 2);
        Contract.Requires(grade <= 6);
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;     
    }
