    public void AddStudent(Student student)
        {
            student.StudentID = (++eCount).ToString();
            student.TimeAdded = DateTime.Now.ToLocalTime(); // or your desired datetime
            students.Add(student);
        }
