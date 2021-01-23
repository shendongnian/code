    public interface IWeapon
        {
            int WeaponDamage { get; }
        }
    
        public interface IBalisticWeapon
        {
            int BallisticDamage { get; }
        }
    
        public interface IProjectile
        {
            int ProjectileDamage { get; }
        }
        
        public abstract class WeaponBase: IWeapon
        {
            public virtual int WeaponDamage { get { return 100; } }//base damage
        }
    
        public class Arrow : WeaponBase, IProjectile, IBalisticWeapon
        {
            public override int WeaponDamage { get { return this.BallisticDamage; } }
    
            public int BallisticDamage { get { return 10; } }
    
            public int ProjectileDamage { get { return this.BallisticDamage; } }
        }
    
        public class BattleAxe : WeaponBase
        {
            //this inherits Weapon Damage from WeaponBase
        }
    
        public class Rock : WeaponBase, IProjectile
        {
            public override int WeaponDamage { get { return this.ProjectileDamage; } }
            public int ProjectileDamage { get { return 10; } }
        }
    
        class Program
        {
            static WeaponBase GetWeapon()
            {
                return new Arrow();
            }
    
            static void Main(string[] args)
            {
                int damage = 0;
                IWeapon weapon = GetWeapon();
                if (weapon is IProjectile)
                {
                    damage = (weapon as IProjectile).ProjectileDamage;
                }
                else if (weapon is IBalisticWeapon)
                {
                    damage = (weapon as IBalisticWeapon).BallisticDamage;
                }
                else
                {
                    damage = (weapon as IWeapon).WeaponDamage;
                }
            }
        }
