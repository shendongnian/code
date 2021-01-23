	public static IEnumerable<int> RandomSequence(int length)
	{
		Random rng = new Random();
		for (int i = 0; i < length; i++) {
			Console.WriteLine("deferred execution!");
			yield return rng.Next();
		}
	}
