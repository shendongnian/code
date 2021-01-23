    class DynamicChildIdComparer : IEqualityComparer<object>
    {
        public bool Equals(object x, object y)
        {
            return ((dynamic)x).ChildID.Equals(((dynamic)y).ChildID);
        }
        public int GetHashCode(object obj)
        {
            return ((dynamic)obj).ChildID.GetHashCode();
        }
    }
