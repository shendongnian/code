    public AuthenticationResult AuthenticateStudent(string studentID, string password)
    {
        var result = students.FirstOrDefault(n => n.StudentID == studentID);
        bool flag = false;
        if (result != null) {...}
        ...
        return new AuthenticationResult {IsValid = flag, ValidatedStudent = result};
    }
