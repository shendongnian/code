    public abstract class Weapon
    {
      public abstract int Clip{get;}//though my bow and sword are both weapons and neither has a clip...
    }
    public class Uzi : Weapon
    {
      public override int Clip
      {
        get { return 5; }
      }
    }
    public class Ak47 : Weapon
    {
      public override int Clip
      {
        get { return 1; }
      }
    }
