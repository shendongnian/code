    interface IProjectile {
        string Name { get; }
    }
    
    // Note the `out` keyword below:
    interface IWeapon<out TProjectile> where TProjectile : IProjectile {
        TProjectile Projectile { get; }
    }
    class BallisticMissile : IProjectile {
        public double Speed { get; set; }
        public string Name { get { return "ballistic missile"; } }
    }
    class BallisticWeapon : IWeapon<BallisticMissile> {
        public BallisticMissile Projectile { get; set; }
    }
    class LaserBeam : IProjectile {
        public double WaveLength;
        public string Name { get { return "laser beam"; } }
    }
    class LaserWeapon : IWeapon<LaserBeam> {
        public LaserBeam Projectile { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            // Manipulate the ballistic weapon in its own specific way:
            var ballisticWeapon = new BallisticWeapon();
            ballisticWeapon.Projectile = new BallisticMissile();
            ballisticWeapon.Projectile.Speed = 2000;
            // Manipulate the laser weapon in its own specific way:
            var laserWeapon = new LaserWeapon();
            laserWeapon.Projectile = new LaserBeam();
            laserWeapon.Projectile.WaveLength = 400;
            // But you can still use both of them as an IWeapon<IProjectile>:
            var weapons = new List<IWeapon<IProjectile>>();
            weapons.Add(ballisticWeapon);
            weapons.Add(laserWeapon);
            foreach (var weapon in weapons)
                Console.WriteLine(weapon.Projectile.Name);
        }
    }
