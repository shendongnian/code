    class School
    {
        public string name;
        private List<Student> students = new List<Student>();
        public School()
        {
        }
        public School(string the_name)
        {
            name = the_name;
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(name);
            foreach (var student in students)
            {
                sb.AppendLine(student.ToString());
            }
            return sb.ToString();
        }
    }
    class Student
    {
        ...
        public override string ToString()
        {
            return "Student : " + Name + ", " + Age;
        }
    }
