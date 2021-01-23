	public class Character : ICharacter
	{
		public string Name { get; private set; }
		
		public int Strength { get; private set; }
		
		public Character(string name, int strength)
		{
			this.Name = name;
			this.Strength = strength;
		}
	}
