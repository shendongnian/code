    public class MyOrderingClass : IEqualityComparer<Student>, IComparer<Student>
    {   
        public int Compare(Student x, Student y)   
        {   
            if (ReferenceEquals(x, y))
            {
                return 0;
            }
            if (ReferenceEquals(x, null))
            {
                throw new ArgumentException("x");
            }
            if (ReferenceEquals(y, null))
            {
                throw new ArgumentException("y");
            }
            int compareName = x.Name.CompareTo(y.Name);   
            if (compareName == 0)   
            {   
                return x.Age.CompareTo(y.Age);   
            }   
            return compareName;   
        }
        public int GetHashCode(Student student)
        {
            if(student == null)
            {
                throw new ArgumentNullException("student");
            }
            unchecked
            {
                return (student.Name ?? String.Empty).GetHashCode ^ (student.Age)
            }
        }
        public bool Equals(Student x, Student y)
        {
            return Compare(x, y) == 0;
        }
    }   
