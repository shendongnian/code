        public RolBaseComparer()
        {
        }
        public bool Equals(RolBase x, RolBase y)
        {
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }
  
            return x.Id.Equals(y.Id) &&
                    x.Nombre.Equals(y.Nombre);
        }
        public int GetHashCode(RolBase obj)
        {
            return obj.Id.GetHashCode() ^ obj.Nombre.GetHashCode();
        }
    }
