	public static void PrintHashMultiBlock(byte[] input, int size)
	{
		SHA256Managed sha = new SHA256Managed();
		int offset = 0;
		while (input.Length - offset >= size)
			offset += sha.TransformBlock(input, offset, size, input, offset);
		sha.TransformFinalBlock(input, offset, input.Length - offset);
		Console.WriteLine("MultiBlock {0:00}: {1}", size, BytesToStr(sha.Hash));
	}
