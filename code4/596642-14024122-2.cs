    public static class WeaponFactory
    {
          public static Weapon Create<T>(Action<T> decorator) where T : IWeapon, new()
          {
               var weapon = new T();
               decorator(weapon);
               return weapon;
          }
          public static void SwordOfDamocles(Sword sword)
          {
               sword.FallTime = GetRandomFallTime();
          }
          public static void SwordOfDestiny(Sword sword)
          {
               sword.Invincible = true;
          }
    }
    var weapon = WeaponFactory.Create(WeaponFactory.SwordOfDamocles);
