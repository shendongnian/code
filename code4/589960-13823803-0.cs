		string test = "3, 7, 12-14, 1, 5-6";
		var items = test.Split(',');
		var ints = items.SelectMany(item => Expand(item));
		string result = string.Join(", ", ints.OrderBy(i => i).ToArray());
		
		private static IEnumerable<int> Expand(string str)
		{
			if (str.Contains('-'))
			{
				var range = str.Split('-');
				int begin = int.Parse(range[0]);
				int end = int.Parse(range[1]);
				for (int i = begin; i <= end; i++)
					yield return i;
			}
			else
				yield return int.Parse(str);
		}
