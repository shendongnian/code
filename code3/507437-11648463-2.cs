    public class Character
    {
        private readonly Random _random = new Random();
    
        public Character(string name, int hitPoints, Range damageRange, int hitChance)
        {
            Name = name;
            HitPoints = hitPoints;
            HitChance = hitChance;
            DamageRange = damageRange;
        }
    
        public string Name { get; set; }
        public int HitChance { get; private set; }
        public int HitPoints { get; private set; }
        public Range DamageRange { get; private set; }
        private bool IsDefending { get; set; }
    
        public bool IsAlive
        {
            get { return HitPoints > 0; }
        }
    
        public void Defend()
        {
            Console.WriteLine("The {0} defends", Name);
            IsDefending = true;
        }
    
        public void Heal(int amount)
        {
            Console.WriteLine("The {0} uses a Potion!", Name);            
            IsDefending = false;
            HitPoints += amount;
            Console.WriteLine("The {0} heals himself for {0} points", amount);
        }
    
        public void Hit(int amount)
        {
            int receivedDamage = IsDefending ? (amount / 2) : amount;
            HitPoints -= receivedDamage;
            Console.WriteLine("The {0} loses {1}hp", Name, receivedDamage);
        }
    
        public void Attack(Character target)
        {
            Console.WriteLine("The {0} attacks!", Name);
            IsDefending = false;
    
            if (HitChance <= _random.Next(0, 100))
            {
                Console.WriteLine("{0} missed!", Name);
                return;
            }
    
            target.Hit(_random.Next(DamageRange.Min, DamageRange.Max));
        }
    }
    
    public class Hero : Character
    {
        public Hero()
            : base("Hero", 1500, new Range(350, 450), 30)
        {
        }   
    }
    
    public class Monster : Character
    {
        public Monster()
            : base("Monster", 2000, new Range(250, 350), 30)
        {
        }
    }
