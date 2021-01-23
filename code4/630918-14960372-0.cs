    internal class GenericComparer<T> : Comparer<T> where T : IComparable<T>
	{
		public override int Compare(T x, T y)
		{
			if (x != null)
			{
				if (y != null)
					return x.CompareTo(y);
				return 1;
			}
			else
			{
				if (y != null)
					return -1;
				return 0;
			}
		}
        // ...
    }
