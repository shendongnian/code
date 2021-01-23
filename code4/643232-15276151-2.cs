    bool IEquatable<ObjectA>.Equals(string rhs) { 
      return this == rhs; 
    }
    public static bool operator != (ObjectA lhs, string rhs) { 
      return ! (lhs == rhs); 
    }
    public static bool operator != (string lhs, ObjectA rhs) { 
      return ! (lhs == rhs); 
    }
    public static bool operator == (ObjectA lhs, string rhs) {
      return (lhs.PropertyX == rhs);
    }
    public static bool operator == (string lhs, ObjectA rhs) {
      return (lhs == rhs.PropertyX);
    }
