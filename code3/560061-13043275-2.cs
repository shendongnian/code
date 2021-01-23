    public class Student : IEquatable<Student>
    {
        private String name;
        private String age;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Age
        {
            get { return age; }
            set { age = value; }
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
    
                hash = hash * 23 + ((Age == null) ? 0 : Age.GetHashCode());
                hash = hash * 23 + ((Name == null) ? 0 : Name.GetHashCode());
    
                return hash;
            }
        }
    
        public bool Equals(Student other)
        {
            if (other == null)
            {
                return false;
            }
    
            return Age == other.Age && Name == other.Name;
        }
    }
----------
    Dictionary<Student, bool> dict = new Dictionary<Student, bool>();
    
    foreach (Student student in list1)
    {
        if (!dict.ContainsKey(student))
        {
            dict.Add(student, false);
        }
    }
    
    ICollection<Student> distinctList = dict.Keys;
