			List<int> set = new List<int> { 1, 2, 3 };
			foreach (var x in GetPermutations(set, 3))
			{
				Console.WriteLine(string.Join(", ", x));
			}
			Console.WriteLine();
			foreach (var x in GetPermutations(set, 2))
			{
				Console.WriteLine(string.Join(", ", x));
			}
			Console.WriteLine();
			foreach (var x in GetOrderedSubSets(set, 2))
			{
				Console.WriteLine(string.Join(", ", x));
			}
