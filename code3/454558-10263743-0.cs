    public void AddStudent(Student student)
    {
        student.StudentID = (++eCount).ToString();
        byte[] passwordHash = Hash(student.Password, GenerateSalt());
        student.TimeAdded = DateTime.Now;
        student.Password= passwordHash;
        students.Add(student);
    }
