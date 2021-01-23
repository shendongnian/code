    public abstract class Projectile {
      public Name { get{return GetType().Name;}  }
      public abstract int Damgage { get; }
    }
 
    public Bullet202: Projectile {
      public override int Damage { get{return 5;} }
    }
    public Bullet303: Projectile {
      public override int Damage { get{return 8;} }
    }
