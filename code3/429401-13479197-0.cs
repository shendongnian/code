		/// <summary>
		/// Compares two string lists using LINQ's SequenceEqual.
		/// </summary>
		public bool CompareLists1(List<string> list1, List<string> list2)
		{
			return list1.SequenceEqual(list2);
		}
		/// <summary>
		/// Compares two string lists using a loop.
		/// </summary>
		public bool CompareLists2(List<string> list1, List<string> list2)
		{
			if (list1.Count != list2.Count)
				return false;
			for (int i = 0; i < list1.Count; i++)
			{
				if (list1[i] != list2[i])
					return false;
			}
			return true;
		}
