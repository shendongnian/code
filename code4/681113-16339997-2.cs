	public class DamageModifierCalculator
	{
		public int Calculate(ICharacter character)
		{
			return (int)Math.Floor(character.Strength / 2);
		}
	}
