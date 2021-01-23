	interface IWeapon
	{
		int Damage { get; }
	}
	class Sword : IWeapon
	{
		public int Damage { get; private set; }
		
		public Sword()
		{
			this.Damage = 50;
		}
	}
