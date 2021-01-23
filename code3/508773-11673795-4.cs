    class UserComparer : IEqualityComparer<UsuersViewModel >
    {
        public bool Equals(UsuersViewModel  x, UsuersViewModel y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            return x.IdUser == y.IdUser;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(UsuersViewModel  user)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(user, null)) return 0;
    
            return user.IdUser == null ? 0 : user.IdUser.GetHashCode();
        }
    }
