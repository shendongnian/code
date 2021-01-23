    public void AddStudent(Student student)
    {
            student.StudentID = (++eCount).ToString();
            student.TimeAdded = student.TimeAdded.ToLocalTime();
            students.Add(student);
    }
