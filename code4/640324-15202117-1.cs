	class Program
	{
		static void Main(string[] args)
		{
			BigInteger v = new BigInteger(-10);
			Console.WriteLine(v.ToSignedHexString());	// Prints: "-0A"
			Console.ReadLine();
		}
	}
	public static class BigIntegerExtensions
	{
		public static string ToSignedHexString(this BigInteger value)
		{
			if (value.Sign == -1)
				return "-" + (-value).ToString("X");
			else
				return value.ToString("X");
		}
	}
