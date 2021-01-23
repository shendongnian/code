     public sealed class NameEqualityComparer : IEqualityComparer<Employee>
     {
            public bool Equals(Employee x, Employee y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }
            public int GetHashCode(Employee obj)
            {
                return (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
      }
