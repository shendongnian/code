    abstract class Enemy
    {
        public abstract float Speed { get; }
    }
    class Zombie : Enemy
    {
        public override float Speed
        {
            get { return 10; }
        }
    }
