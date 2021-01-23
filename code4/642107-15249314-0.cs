    abstract class Enemy
    {
        public abstract float GetSpeed();
    }
    class Zombie : Enemy
    {
        public override float GetSpeed()
        {
            return 10;
        }
    }
