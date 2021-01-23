	public class Fruit
	{
		string TypeOfFruit { get; set; }
		public Fruit (string typeOfFruit)
		{
			TypeOfFruit = typeOfFruit;
		}
	}
	public class Apple : Fruit
	{
		string AppleType { get; set; }
		public Apple(string appleType) : base("Apple")
		{
			AppleType = appleType;
		}
	}
