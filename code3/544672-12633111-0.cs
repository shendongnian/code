    public class Deck
	{
		public static Deck GetDeck(String type)
		{
			if (type.Equals("Standard", StringComparison.OrdinalIgnoreCase))
			{
				return new Deck(type, 60);
			}
			else if (type.Equals("Extended", StringComparison.OrdinalIgnoreCase))
			{
				return new Deck(type, 100);
			}
		}
	}
