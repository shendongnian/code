    public partial class UnitType {
      public static readonly UnitType Mass = new UnitType("Mass");
      public static readonly UnitType Length = new UnitType("Length");
    }
    public partial class Unit {
      public static readonly Unit Grams = new Unit("g", UnitType.Mass);
      public static readonly Unit Kilos = new Unit("kg", UnitType.Mass);
      // ...
    }
