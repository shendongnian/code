    public class Student
    {
        // ...
        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType()) 
                return false;
            Student other = obj as Student;
            return this.Id == other.Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
    public class StudentList : List<Student> { }
    // Usage:
    var students = new StudentList();
    students.Add(student);
