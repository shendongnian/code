    public class Student : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return (x.Id == y.Id);
        }
        public int GetHashCode(Student obj)
        {
            return obj.GetHashCode();
        }
    }
