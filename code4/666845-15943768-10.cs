    public class PreferZombiesMonsterFactory : IMonsterFactory
    {
        public Zombie CreateZombie(string name)
        {
            return new SuperAwesomeZombie(name);
        }
        public Vampire CreateVampire(int age)
        {
            return new BooringVampire(age);
        }
    }
