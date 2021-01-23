    public sealed class Unit { 
      public static Unit Value { get { return null; } }
      public static implicit operator Unit(object source) {
        return Value;
      }
    }
