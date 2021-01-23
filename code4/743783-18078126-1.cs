    public class InventoryObject
    {
        protected Dictionnary<Type, InventoryObject> _combinations = new Dictionnary<Type, InventoryObject>();
        public InventoryObject() {}       
        public InventoryObject Combine(InventoryObject o)
        {
           foreach (var c in _combinations)
              if (typeof(o) == c.Key)
                return c.Value
           throw new Exception("These objects aren't combinable");
        }
    }
    public class BlueHerb : InventoryObject
    {
        public Herb()
        {
           _combinations.Add(RedHerb, new BlueRedHerb());
           _combinations.Add(GreenHerb, new BlueGreenHerb());
        }
    }
    public class BlueRedHerb: InventoryObject
    {
        public BlueRedHerb()
        {
           _combinations.Add(GreenHerb, new GreyHerb());
        }
    }
