	class FakeDateTime
	{
		private static int currentIndex = -1;
		private static DateTime[] testDateTimes = new DateTime[]
			{
				new DateTime(2012,5,8,8,50,10),
				new DateTime(2012,5,8,8,50,10)	//List out the times you want to test here
			};
		/// <summary>
		/// The property to access to check the time.  This would replace DateTime.Now.
		/// </summary>
		public DateTime Now
		{
			get
			{
				currentIndex = (currentIndex + 1) % testDateTimes.Length;
				return testDateTimes[currentIndex];
			}
		}
		/// <summary>
		/// Use this if you want to specifiy the time.
		/// </summary>
		/// <param name="timeIndex">The index in <see cref="testDateTimes"/> you want to return.</param>
		/// <returns></returns>
		public DateTime GetNow(int timeIndex)
		{
			return testDateTimes[timeIndex % testDateTimes.Length];
		}
	}
