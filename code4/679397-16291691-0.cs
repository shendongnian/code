    abstract class Weapon
    {
        public abstract void Fire();
    }
    class BallisticWeapon
    {
        virtual public void Fire()
        {
            // Ballistic fire
        }
    }
    // Weapon need ballistic fire
    class WeaponA : BallisticWeapon
    {
    }
    // Weapon don't need ballistic fire
    class WeaponB : Weapon
    {
        // Implement fire
        public void Fire()
        {
        }
    }
