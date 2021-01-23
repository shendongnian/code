    public class Inventory {
      private IItem[] _items = new IItem[10];
      public IItem[int idx] { get { return _items[idx]; } set { _items[idx] = value; } }
      public IWeapon CurrentWeapon { get { return (IWeapon)_items[0]; }}
      public IArmour CurrentArmour { get { return (IArmour)_items[1]; } }
    }
