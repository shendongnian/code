    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Durability { get; set; }
        // Consider moving this method to another class.
        public static IEnumerable<Weapon> CreateWeapons()
        {
            List<Weapon> weapons = new List<Weapon>();
            Weapon shortSword = new Weapon { Damage = 5, Durability = 20 };
            weapons.Add(shortSword);
            Weapon woodenBow = new Weapon { Damage = 3, Durability = 15 };
            weapons.Add(woodenBow);
            return weapons;
        }
    }
