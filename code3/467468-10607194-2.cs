    public static class LocalConstants
	{
		public static string DM_PATH = "DMQueue";
		public static string PROJECT_PATH = "MSQueue";
	}
	class Program
	{
		static void Main(string[] args)
		{
			string moomoo = LocalConstants.PROJECT_PATH;
			Console.WriteLine(moomoo);
		}
	}
