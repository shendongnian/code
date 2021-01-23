    class Ammo
    {
    }
    class Clip : Ammo
    {
    }
    class AmmoBox : Ammo
    {
    }
    class Firearm
    {
    }
    interface IClipAmmo
    {
    }
    interface IBoxAmmo
    {
    }
    class ClipWeapon : Firearm, IClipAmmo, IBoxAmmo
    {
    }
    class AmmoBoxWeapon : Firearm, IBoxAmmo
    {
    }
    static class IClipAmmoReloadExtension
    {
        public static void Reload(this IClipAmmo firearm, Clip ammo)
        {
        }
    }
    static class IBoxAmmoReloadExtension
    {
        public static void Reload(this IBoxAmmo firearm, AmmoBox ammo)
        {
        }
    }
