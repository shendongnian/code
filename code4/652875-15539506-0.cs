    public enum EnemyType
    {
        Zombie,
        Vampire
    }
    public class Enemy
    {
        private EnemyType mType;
        protected Enemy(EnemyType type) { mType = type; }
        public EnemyType getEnemyType() { return mType; }
        public void walk() { }
 
        public void attack() { }
        public void eatBrains() { }
    }
    public class Vampire : Enemy
    {
        public Vampire : base(EnemyType.Vampire) { }
        public void walk()
        {
            // walk like a vampire
        }
        public void attack()
        {
            // attack like a vampire
        }
        // don't bother implementing eatBrains() because vampires don't do this
        // calling code will use getEnemyType() and won't bother call our eatBrains() method anyway
    }
