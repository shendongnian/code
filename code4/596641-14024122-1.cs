    public static class WeaponFactory
    {
           public static Weapon CreateSword(SwordType type)
           {
                var sword = new Sword(); // plain, old default sword
                     
                // override properties based on type
                switch (type)
                {
                    case SwordType.SwordOfDamocles:
                        sword.FallTime = GetRandomFutureTime();
                        break;
                    case SwordType.SwordOfDestiny:
                        sword.Invincible = true;
                        break;
                    ...
                }
                return sword;
            }
            ...
    }
