    public class Student: IEquatable<Student>
    {
        ...
        public bool Equals(Student other)
        {
            return name == other.name && age == other.age 
                        && lastExam.Equals(other.lastExam);
        }
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            return Equals(student);
        }
        public override int GetHashCode()
        {
            return name.GetHashCode() ^ 
                 age.GetHashCode() ^ lastExam.GetHashCode();
        }
    }
