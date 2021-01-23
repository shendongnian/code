    public class Inventory {
      public IWeapon CurrentWeapon { get; }
      public IArmour CurrentArmour { get; }
      private IItem[] _items = new IItem[8];
      public IItem[int idx] {
        get {
          return
            idx == 0 ? CurrentWeapon :
            idx == 1 ? CurrentArmour :
            idx_items[idx - 2];
        }
      }
    }
