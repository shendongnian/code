	public static class Golden
	{
		public static IEnumerable<long> Fibonacci()
		{
			var a = 0L;
			var b = 1L;
			var s = 0L;
			yield return a;
			while (a < long.MaxValue - b)
			{
				yield return b;
				s = a + b;
				a = b;
				b = s;
			}
		}
		public static IEnumerable<long> FibonacciR()
		{
			IEnumerable<long> Fibo(long a, long b)
			{
				yield return a;
				if (a < long.MaxValue - b)
				{
					foreach (var v in Fibo(b, a + b))
					{
						yield return v;
					}
				}
			}
			return Fibo(0, 1);
		}
	}
