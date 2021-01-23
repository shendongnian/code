    public bool Equals(MyClass other) // IEquatable<MyClass> implementation
    {
      if (other == null) {
        return false;
      }
      return this.ID == other.ID;
    }
    public override bool Equals(object other) // Override of default Object.Equals()
    {
      return this.Equals(other as MyClass);
    }
    public override int GetHashCode()
    {
      // ID may not always be int, and the ID type might have a more
      // useful implementation of GetHashCode() to offer.
      return this.ID.GetHashCode(); 
    }
