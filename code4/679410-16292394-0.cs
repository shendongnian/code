    public class BalisticWeapon
    {
      public BalisticWeapon(){}
    
      public override BalisticProjectile weaponprojectile
      {
        get { return Base.weaponprojectile; }
        set { Base.Weaponprojectile = value; }
      }
    
      public override void Fire()
      {
        //Handle special case for Firing BalisticProjectile
      }
    }
