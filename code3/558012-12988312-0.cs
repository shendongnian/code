    class AssignUserViewModel
    {
        // other methods...
            
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is AssignUserViewModel))
                throw new ArgumentException("obj is not an AssignUserViewModel");
            var usr = obj as AssignUserViewModel;
            if (usr == null)
                return false;
            return this.Id.Equals(usr.Id);
        }
    }
