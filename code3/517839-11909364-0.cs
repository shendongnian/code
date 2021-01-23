    public String UseAsDisplayMember
    {
        get 
        {
            return EnrollmentData.StudentData.StudentID; 
        }
    }
    public string UseAsValueMember
    {
        get 
        {
            return EnrollmentData.CourseData.CourseID; 
        }
    }
