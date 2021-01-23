	// base digit class
	public class Digit
	{
		public int N { get; set; }
		// default output
		public virtual string Print()
		{
			return string.Format("I am base digit: {0}", this.N);
		}
	}
	public class One : Digit
	{
		public One()
		{
			this.N = 1;
		}
		// i want my own output
		public override string Print()
		{
			return string.Format("{0}", this.N);
		}
	}
	public class Two : Digit
	{
		public Two()
		{
			this.N = 2;
		}
		// i will use the default output!
	}
