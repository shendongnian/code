	interface IDamageModifier
	{
		int Damage { get; set; }
	}
	class EquippedWeapon : IWeapon
	{
		public int Damage
		{
			get
			{
				return CalculateActualDamage();
			}
		}
		
		public List<IDamageModifier> DamageModifiers { get; set; }	
		private IWeapon _baseWeapon = null;
		
		public EquippedWeapon(IWeapon weapon)
		{
			_baseWeapon = weapon;		
		}
		
		private int CalulcateActualDamage()
		{
			int baseDamage = _baseWeapon.Damage;
			
			foreach (var modifier in this.DamageModifiers)
			{
				baseDamage += modifier.Damage;
			}
			
			return baseDamage;
		}
	}
