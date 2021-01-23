  		class Program
	{
		static void Main(string[] args)
		{
			string[,] array = new string[,]
			{ 
				 { "ab","ab","ab","FREE","me","me","me","FREE","mo","mo","FREE","FREE"},
				 { "so","so","FREE","no","no","FREE","to","to","to","FREE","do","do"}
			};
			Console.WriteLine(string.Join(", ", string.Join(", ", array.Cast<string>())));
			List<PackedItem> packed = Pack(array);
			Shuffle(packed);
			int rows = array.GetLength(0);
			int columns = array.GetLength(1);
			string[,] unpacked = Unpack(packed, rows, columns);
			Console.WriteLine(string.Join(", ", string.Join(", ", unpacked.Cast<string>())));
			Console.ReadKey();
		}
		internal sealed class PackedItem
		{
			public string Value { get; private set; }
			public int Count { get; set; }
			public PackedItem(string value)
			{
				Value = value;
				Count = 1;
			}
			public override string ToString()
			{
				return string.Format("{0} - {1}", Value, Count);
			}
		}
		private static List<PackedItem> Pack(string[,] array)
		{
			var list = new List<PackedItem>();
			foreach (string s in array)
			{
				if (list.Count == 0)
				{
					list.Add(new PackedItem(s));
					continue;
				}
				var last = list[list.Count - 1];
				if (s == last.Value)
				{
					last.Count += 1;
					continue;
				}
				else
				{
					list.Add(new PackedItem(s));
					continue;
				}
			}
			return list;
		}
		private static string[,] Unpack(List<PackedItem> inputList, int rows, int columns)
		{
			var list = inputList.ToList();
			string[,] result = new string[rows, columns];
			for (int i = 0; i < rows; i++)
			{
				List<PackedItem> packedRow = Pick(list, columns);
				packedRow.ForEach(x => list.Remove(x));
				List<string> row = packedRow
									.Select(x => ExpandPackedItem(x))
									.Aggregate(seed: new List<string>(),
											func: (acc, source) => { acc.AddRange(source); return acc; });
				for (int j = 0; j < columns; j++)
				{
					result[i, j] = row[j];
				}
			}
			return result;
		}
		private static List<PackedItem> Pick(List<PackedItem> list, int count)
		{
			int addedCount = 0;
			var added = new List<PackedItem>();
			for (int i = 0; i < list.Count; i++)
			{
				PackedItem item = list[i];
				if (item.Count + addedCount > count)
					continue;
				added.Add(item);
				addedCount += item.Count;
				if (addedCount == count)
					break;
			}
			return added;
		}
		private static void Shuffle(List<PackedItem> list)
		{
			Random r = new Random();
			for (int i = 0; i < list.Count; i++)
			{
				int a = r.Next(0, list.Count);
				int b = r.Next(0, list.Count);
				Swap(list, a, b);
			}
		}
		private static void Swap(List<PackedItem> list, int a, int b)
		{
			var temp = list[b];
			list[b] = list[a];
			list[a] = temp;
		}
		public static string[] ExpandPackedItem(PackedItem item)
		{
			string[] result = new string[item.Count];
			for (int i = 0; i < item.Count; i++)
			{
				result[i] = item.Value;
			}
			return result;
		}
	}
}
