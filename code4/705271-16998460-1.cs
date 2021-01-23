	public static byte[] GetNumbers(string data)
	{
		if (data == null) throw new ArgumentNullException();
		if (data.Length % 2 != 0
			   || !data.All(char.IsDigit)) throw new ArgumentException();
		List<byte> temp = new List<byte>(data.Length / 2);
		for (int i = 0; i < data.Length; i += 2)
		{
			temp.Add(byte.Parse(string.Concat(data[i], data[i + 1]),
				NumberStyles.HexNumber));
		}
		return temp.ToArray();
	}
