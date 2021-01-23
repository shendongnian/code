	using System;
	class MyAwesomeLibrary
	{
		static MyAwesomeLibrary()
		{
			Console.WriteLine(string.Format("Hey {0} is using me!", Environment.UserName));
		}
		
		public static int GetTheAnswer()
		{
			return 42;
		}
	}
	class Client
	{
		static void Main()
		{
			Console.WriteLine("The answer is: " + MyAwesomeLibrary.GetTheAnswer());
		}
	}
