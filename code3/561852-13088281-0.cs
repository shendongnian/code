    public class Character
    {
        public string Name { get; private set; }
        
        public int HitPoints { get; private set; }
        public int Offense { get; private set; }
        public int Defense { get; private set; }
        public Character(string name, int hitPoints, int offense, int defense)
        {
            Name = name;
            HitPoints = hitPoints;
            Offense = offense;
            Defense = defense;
        }
        public void Defend(Character source)
        {
            HitPoints = HitPoints - (source.Offense - Defense);
            if (HitPoints <= 0)
            {
                 Console.WriteLine("{0} died", Name);
            }
        }
        public void Attack(Character target)
        {
            // Here you can call the other character's defend with this char as an attacker
            target.Defend(this);
            if (target.HitPoints <= 0)
            {
                Console.WriteLine("{0} killed {1}", Name, target.Name);
            }
        }
    }
