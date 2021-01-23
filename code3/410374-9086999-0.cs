	public static void RunSnippet()
	{
		Stack<int> hello = new Stack<int>();
		hello.Push(1); hello.Push(2); hello.Push(3);
		
		while (hello.Count > 0)
		{
			int x = hello.Pop();
			Console.WriteLine(x);
			if (x == 1) {
				hello.Push(100);
			}
		}
	}
