	var dict1 = new Dictionary<int, string>();
		var dict2 = new Dictionary<int, string>();
				
		Parallel.Invoke(() =>
		{
			for(int i = 0; i < 500000; i++)
			{
				dict1.Add(i, "Test" +i);
				dict2.Add(i, "Test" +i);
			}
		},
		() =>
		{
			for(int i = 500000; i < 1000000; i++)
			{
				dict1.Add(i, "Test" +i);
				dict2.Add(i, "Test" +i);
			}
		});
