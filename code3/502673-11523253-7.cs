	[TestMethod]
	public void SomeBenchmark()
	{
		List<double> forLoopTimes = new List<double>();
		List<double> forLoop2Times = new List<double>();
		List<double> toDictionaryTimes = new List<double>();
		List<double> hybridTimes = new List<double>();
		string[] array = Enumerable.Range(0, 5000).Select(i => i.ToString()).ToArray();
		Dictionary<int, string> dictionary;
		int runCount = 5000;
		int arrayLen = array.Length;
		while (runCount-- != 0)
		{
			Stopwatch sw = Stopwatch.StartNew();
			dictionary = new Dictionary<int, string>();
			for (int i = 0; i < array.Length; i++)
			{
				dictionary[i] = array[i];
			}
			sw.Stop();
			forLoopTimes.Add(sw.Elapsed.TotalMilliseconds);
			sw.Restart();
			dictionary = new Dictionary<int, string>();
			for (int i = 0; i < arrayLen; i++)
			{   //same as before - but using arrayLen instead of property
				dictionary[i] = array[i];
			}
			sw.Stop();
			forLoop2Times.Add(sw.Elapsed.TotalMilliseconds);
			sw.Restart();
			dictionary = array.Select((s, i) => new { Key = i, Value = s }).ToDictionary(v => v.Key, v => v.Value);
			sw.Stop();
			toDictionaryTimes.Add(sw.Elapsed.TotalMilliseconds);
			int counter = 0;
			sw.Restart();
			dictionary = array.ToDictionary(s => counter++, s => s);
			sw.Stop();
			hybridTimes.Add(sw.Elapsed.TotalMilliseconds);
		}
		Console.WriteLine("for loop average: {0} milliseconds", forLoopTimes.Average());
		Console.WriteLine("for loop(2) average: {0} milliseconds", forLoop2Times.Average());
		Console.WriteLine("ToDictionary average: {0} milliseconds", toDictionaryTimes.Average());
		Console.WriteLine("Hybrid average: {0} milliseconds", hybridTimes.Average());
	}
