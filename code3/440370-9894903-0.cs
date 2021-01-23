	public static class TwoDArrayExtensions
	{
		public static void ClearTo(this int[,] a, int val)
		{
			for (int i=a.GetLowerBound(0); i <= a.GetUpperBound(0); i++)
			{
				for (int j=a.GetLowerBound(1); j <= a.GetUpperBound(1); j++)
				{
					a[i,j] = val;
				}
			}
		}
	}
