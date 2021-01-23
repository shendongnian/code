	public IEnumerable<int> GetNextNumber()
	{
		while (true)
		{
			for (int i = 0; i < 10; i++)
			{
				yield return i;
			}
		}
	}
	public bool Canceled { get; set; }
	public void StartCounting()
	{
		foreach (var number in GetNextNumber())
		{
			if (this.Canceled) break;
			Console.WriteLine(number);
		}
	}
