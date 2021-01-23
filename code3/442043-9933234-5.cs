	public class Card
	{
		private readonly Suit _suit = 0;
		private readonly int _nCardNumber = 0;
		
		public Card(int a_nNumber)
		{
			_nSuitNumber = a_nNumber / 13;  // 1 = Hearts, 2 = Diamonds ...
			_nCardNumber = a_nNumber % 13;  // 1 = ace, 2 = two
		}
		
		public Suit Suit
		{
			get { return _suit; }
		}
		public int CardNumber
		{
			get { return _nCardNumber; }
		}
		public int ToNumber()
		{
			return (int)_suit * 13 + _nCardNumber;
		}
	}
	
	public enum Suit
	{
		Hearts = 0,
		Diamonds = 1,
		Clubs = 2,
		Spades = 3
	}
