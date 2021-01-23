    class AssignUserViewModelEqualityComparer : IEqualityComparer<AssignUserViewModel>
    {
        public bool Equals(AssignUserViewModel x, AssignUserViewModel y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            return x.Id.Equals(y.Id);
        }
        public int GetHashCode(AssignUserViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
