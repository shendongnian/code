	MyData LineToMyData(string line)
	{
		try
		{
			string[] arr = line.Split('\t');
			return new MyData()
			{
				Time = DateTime.Parse(arr[0]),
				Name = arr[1],
				Age = Int32.Parse(arr[2])
			};
		}
		catch (Exception ex)
		{
			throw new ArgumentException("line", ex);
		}
	}
