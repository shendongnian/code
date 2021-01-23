		public Keyword GetMaxKeyword(IEnumerable<Bookmark> bookmarks)
		{
			int max = 0;
			Keyword maxkw = null;
			Dictionary<Keyword, int> lookup = new Dictionary<Keyword, int>();
			foreach (var item in bookmarks)
			{
				foreach (var kw in item.Keywords)
				{
					int val = 1;
					if (lookup.ContainsKey(kw))
					{
						val = ++lookup[kw];
					}
					else
					{
						lookup.Add(kw, 1);
					}
					if (max < val)
					{
						max = val;
						maxkw = kw;
					}
				}
			}
			return maxkw;
		}
