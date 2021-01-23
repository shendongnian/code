	var dict1 = new ConcurrentDictionary<int, string>();
		var dict2 = new ConcurrentDictionary<int, string>();
				
		Parallel.Invoke(() =>
		{
			for(int i = 0; i < 500000; i++)
			{
				dict1[i] = "Test" +i;
				dict2[i] ="Test" +i;
			}
		},
		() =>
		{
			for(int i = 500000; i < 1000000; i++)
			{
				dict1[i] ="Test" +i;
				dict2[i] = "Test" +i;
			}
		});
