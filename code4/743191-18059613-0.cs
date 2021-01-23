		[TestMethod]
		public void ArgumentOutOfRangeExceptionTest()
		{
			string test = "abc";
			int i = 0;
			try
			{
				while (true)
				{
					test.ElementAt(i);
					i++;
				}
			}
			catch (ArgumentOutOfRangeException)
			{ }
		}
