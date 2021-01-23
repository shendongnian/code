    abstract class Item
    {
        public string Name { get; set; }
    }
    class Weapon : Item
    {
        public int Power { get; set; }
    }
    class Armor : Item
    {
        public int Resistance { get; set; }
    }
