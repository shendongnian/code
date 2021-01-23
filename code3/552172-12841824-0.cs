    public abstract class Animal
	{
		public abstract int NumberOfLegs { get; }
		public void Walk()
		{
			// do something based on NumberOfLegs
		}
	}
	public class Cat : Animal
	{
		private const int NumLegs = 4;
		public override int NumberOfLegs { get { return NumLegs; } }
	}
	public class Spider : Animal
	{
		private const int NumLegs = 8;
		public override int NumberOfLegs { get { return NumLegs; } }
	}
