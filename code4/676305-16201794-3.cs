    // IEquatable<MyClass> implementation
    public bool Equals(MyClass other) 
    {
      if (other == null) 
      {
        return false;
      }
      return this.ID == other.ID;
    }
    // Override of default Object.Equals()
    public override bool Equals(object other) 
    {
      return this.Equals(other as MyClass);
    }
    public override int GetHashCode()
    {
      // Call ID.GetHashCode() because ID may not always be int,
      // and the ID type might have a more useful implementation
      // of GetHashCode() to offer.
      return this.ID.GetHashCode(); 
    }
