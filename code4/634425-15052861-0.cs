    class School
    {
        public string name;
        private List<Student> students = new List<Student>();
        // ...
        public void AddStudent(Student student)
        { 
            students.Add(student);
        }
    }
