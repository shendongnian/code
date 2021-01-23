    public class AssignedClassComparer : IEqualityComparer<AssignedClass>
    {
        public bool Equals(AssignedClass x, AssignedClass y)
        {
            return x.RequestNumber == y.RequestNumber;
        }
        public int GetHashCode(AssignedClass obj)
        {
            return obj.RequestNumber.GetHashCode();
        }
    }
