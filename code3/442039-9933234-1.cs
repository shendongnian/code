   	public class Card
	{
		private readonly int _nSuitNumber = 0;
		private readonly int _nCardNumber = 0;
		public Card(int a_nNumber)
		{
			_nSuitNumber = a_nNumber / 13;  // 1 = Hearts, 2 = Diamonds ...
			_nCardNumber = a_nNumber % 13;  // 1 = ace, 2 = two
		}
	}
