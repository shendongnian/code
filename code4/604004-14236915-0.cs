    class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x == null || y == null) return false;
            bool equals = x.ID==y.ID && x.Name == y.Name && x.Dept == y.Dept 
                && x.Address == y.Address && x.Age == y.Age && x.Email == y.Email;
            return equals;
        }
        public int GetHashCode(Employee obj)
        {
            if (obj == null) return int.MinValue;
            int hash = 19;
            hash = hash + obj.ID.GetHashCode();
            hash = hash + obj.Name.GetHashCode();
            hash = hash + obj.Dept.GetHashCode();
            hash = hash + obj.Address.GetHashCode();
            hash = hash + obj.Age.GetHashCode();
            hash = hash + obj.Email.GetHashCode();
            return hash;
        }
    }
