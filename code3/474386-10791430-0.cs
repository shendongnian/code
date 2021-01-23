    public partial class UnitType {
      public string Name { get; private set; }
      public UnitType(string name) {
        Name = name;
      }
    }
    
    public partial class Unit {
      public string Name { get; private set; }
      public UnitType Type { get; private set; }
      public Unit(string name, UnitType type) {
        Name = name;
        Type = type;
      }
    }
