    public override bool Equals(object obj) { 
      return (obj is ObjectA) && this == (ObjectA)obj; 
    }
    bool IEquatable<ObjectA>.Equals(ObjectA rhs) { 
      return this == rhs; 
    }
    public static bool operator != (ObjectA lhs, ObjectA rhs) { 
      return ! (lhs == rhs); 
    }
    public static bool operator == (ObjectA lhs, ObjectA rhs) {
      return (lhs.PropertyX == rhs.PropertyX);
    }
    public override int GetHashCode() { 
      return PropertyX.GetHashCode() 
    }
