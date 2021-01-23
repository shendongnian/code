	public static class StringEncoder
	{
		static byte[] EncodeToBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}
		static string DecodeToString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}
	}
	public static class BytesEncoder
	{
		public static string EncodeToString(byte[] bytes)
		{
			bool even = (bytes.Length % 2 == 0);
			char[] chars = new char[1 + bytes.Length / sizeof(char) + (even ? 0 : 1)];
			chars[0] = (even ? '0' : '1');
			System.Buffer.BlockCopy(bytes, 0, chars, 2, bytes.Length);
			return new string(chars);
		}
		public static byte[] DecodeToBytes(string str)
		{
			bool even = str[0] == '0';
			byte[] bytes = new byte[(str.Length - 1) * sizeof(char) + (even ? 0 : -1)];
			char[] chars = str.ToCharArray();
			System.Buffer.BlockCopy(chars, 2, bytes, 0, bytes.Length);
			return bytes;
		}
	}
