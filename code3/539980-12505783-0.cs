    public override string ToString()
    {
        string classNumberAndName = getClassNumberAndName();
        for(int i = 0; i < students.Length; i++)
        {
            if (students[i] != null)
                classNumberAndName += ((Student)students[i]).ToString();
        }
        classNumberAndName += "Students Registered: " + numberOfStudents.ToString();
        return classNumberAndName;
    }
