    class MainClass
    {
        public static void Main(string[] args)
        {
			string str = "12341234";
			byte[] buffer = Encoding.ASCII.GetBytes(str);
			Stopwatch sw = Stopwatch.StartNew();
			for(int i = 0; i <   1000000 ;i ++)
			{
				long val = BufferToLong.GetValue(buffer);
			}
			Console.WriteLine (sw.ElapsedMilliseconds);
			sw.Restart();
			for (int i = 0 ; i < 1000000 ; i++)
			{
				string valStr = Encoding.ASCII.GetString(buffer);
				long val = long.Parse(valStr);
			}
			Console.WriteLine (sw.ElapsedMilliseconds);
        }
    }
	static class BufferToLong
	{
		public static long GetValue(Byte[] buffer) {
			long number = 0;
			foreach (byte currentByte in buffer) {
				char currentChar = (char)currentByte;
				int currentDigit = currentChar - '0';
				number *= 10 ;
				number += currentDigit;
			}
			return number;
		}
	}
