	List<DateTime> randomTimes = new List<DateTime>();
	Random r = new Random();
	DateTime d = new DateTime(2012, 11, 27, 7, 0, 0);
	
	for (int i = 0; i < 100; i++)
	{
		TimeSpan t = TimeSpan.FromSeconds(r.Next(0, 14400));
		randomTimes.Add(d.Add(t));
	}
	randomTimes.Sort();
