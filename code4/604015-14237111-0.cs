    public class Employee
    {
        public int ID = 0;
        public string Name = String.Empty;
        public string Dept = String.Empty;
        public string Address = String.Empty;
        public int Age = 0;
        public string Email = String.Empty;
        public override int GetHashCode()
        {
            return
                ID.GetHashCode() ^
                (Name ?? String.Empty).GetHashCode() ^
                (Dept ?? String.Empty).GetHashCode() ^
                (Address ?? String.Empty).GetHashCode() ^
                Age.GetHashCode() ^
                (Email ?? String.Empty).GetHashCode()
                ;
        }
        public override bool Equals(object obj)
        {
            Employee other = obj as Employee;
            if (obj == null)
                return false;
            return ID == other.ID &&
                    Name == other.Name &&
                    Dept == other.Dept &&
                    Address == other.Address &&
                    Age == other.Age &&
                    Email == other.Email;
        }
    }
