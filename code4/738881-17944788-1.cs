    class Ammo {}
    class Clip : Ammo {}
    class AmmoBox : Ammo {}
    class Firearm {}
    interface IClipReloadable {}
    interface IAmmoBoxReloadable {}
    class ClipWeapon : Firearm, IClipReloadable, IAmmoBoxReloadable {}
    class AmmoBoxWeapon : Firearm, IAmmoBoxReloadable {}
    static class IClipReloadExtension {
        public static void Reload(this IClipReloadable firearm, Clip ammo) {}
    }
    static class IAmmoBoxReloadExtension {
        public static void Reload(this IAmmoBoxReloadable firearm, AmmoBox ammo) {}
    }
