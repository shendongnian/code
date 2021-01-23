    public class Weapon : Item
    {
        public int Damage { get; set; }
        // also has a copy constructor
        public Weapon(Weapon other) : base(other) // Item copies it's stuff!
        {
            Damage = other.Damage;
        }
        // Need to implement this:
        public override Item Clone() { return new Weapon(this); }
    }
