	public static BigInteger FindNearestPowerOfTwo(BigInteger number) {
		bool isPower = number.IsPowerOfTwo;
		int count = 0;
		while(!number.IsZero) {
			Console.WriteLine(number);
			number = number >> 1;
			count ++ ;
		}
		return BigInteger.Pow(2, count - (isPower ? 2: 1));
	}
