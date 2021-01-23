	public static bool TryGetNumbers(string data, out byte[] output)
	{
		if (data == null || data.Length % 2 != 0 || !data.All(char.IsDigit))
		{
			output = null;
			return false;
		}
		List<byte> temp = new List<byte>(data.Length / 2);
		for (int i = 0; i < data.Length; i += 2)
		{
			temp.Add(byte.Parse(string.Concat(data[i], data[i + 1]),
				NumberStyles.HexNumber));
		}
		output = temp.ToArray();
		return false;
	}
