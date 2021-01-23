    public void AddStudent(Student student)
        {
            student.StudentID = (++eCount).ToString();
            student.TimeAdded = DateTime.Today.ToLocalTime(); // or your desired datetime
            students.Add(student);
        }
