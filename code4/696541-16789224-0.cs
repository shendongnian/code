	class Data
	{
		const int Step = 2;
		List<int[]> data;
		List<int> cursors;
		public Data()
		{
			data = new List<int[]>();
		}
		public void AddArray(int[] array)
		{
			data.Add(array);
			cursors.Add(array.Length);
			// or cursors.Add(0), depending on your needs
		}
		public void Tick()
		{
			for (int i = 0; i < cursors.Count; i++)
			{
				cursors[i] -= Step;
				// or cursors[i] += Step, depending on your needs
			}
		}
		public IEnumerable<int> GetValuesAtIndex(int index)
		{
			for (int i = 0, i < data[index].Length; i++)
			{
				if (i > cursors[index]) // or i < cursors[index]
				{
					yield return data[index][i];
				}
			}
		}
	}
