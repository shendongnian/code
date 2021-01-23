	IEnumerable<DateTime> GetTimes(int count)
	{
		for (int i = 0; i < count; i++)
		{
			Console.WriteLine("returning the value with index " + i);
			yield return DateTime.Now.AddDays(i);
		}
		Console.WriteLine("About to hit the `yield break`! Awesome!");
		yield break;
	}
