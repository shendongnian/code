    public abstract class Bullet
    {
        public abstract int Damage { get; set; }
    }
    public class SomeBullet : Bullet
    {
        public override int Damage { get; set; }  //This has to be implemented.
        ...
    }
