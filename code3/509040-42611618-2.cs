	void Main()
	{
		Console.WriteLine(WhoKnocked(1,2,3));
	}
		
	public string WhoKnocked(int x, params int[] knocks)
	{
		return "It's mee!";
	}
	
	public string WhoKnocked(params int[] knocks)
	{
		return "No, it's not, its you!";
	}
