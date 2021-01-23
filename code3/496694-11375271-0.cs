		private class ListComparer : EqualityComparer<List<int>>
		{
			public override bool Equals(List<int> x, List<int> y)
			{
				if (x.Count != y.Count)
					return false;
				x.Sort();
				y.Sort();
				for (int i = 0; i < x.Count; i++)
				{
					if (x[i] != y[i])
						return false;
				}
				return true;
			}
			public override int GetHashCode(List<int> list)
			{
				int hc = 0;
				foreach (var i in list)
					hc ^= i;
				return hc;
			}
		}
