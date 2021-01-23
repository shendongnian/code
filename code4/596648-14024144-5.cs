	class Player
	{
		public EquippedWeapon PrimaryWeapon { get; set; }
		
		public Player()
		{
			this.PrimaryWeapon = new EquippedWeapon(new Sword());
		}
		
		public void UnderAttack(Attack attack)
		{
			// TODO: implement
			
			if (attack.Buffs...)
			{
				this.EquippedWeapon.DamageModifiers.Add(attack.Buffs);
			}
		}
	}
