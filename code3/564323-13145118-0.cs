        public void AddStudent(Student student)
        {
            if (students == null)
            {
                students.Add(student);
            }
            else
            {
                foreach (var s in students)
                {
                    if (student.Id == s.Id)
                    {
                        throw new ArgumentException("Error student "
                        + student.Name + " is already in the class");
                    }
                }
                students.Add(student);
            }
        }
