    private class EmailEqComparer : IEqualityComparer<User>
    {
      public bool Equals(User x, User y)
      {
        //don't bother shortcutting on reference equality, since if they come from
        //separate web-calls it's unlikely to happen, though it could
        //with some optimisations on the web-client code.
        if(x == null)
          return y == null;
        if(y == null)
          return false;
        return x.Email == y.Email;
      }
      public int GetHashCode(User obj)
      {
        return obj == null ? 0 : obj.Email.GetHashCode();
      }
    }
