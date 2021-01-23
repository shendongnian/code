    private void bw_DoWork()
		{
			Task.Factory.StartNew(
				() =>
				{
					 var r = new Random();
					for (int j = 1; j <= 100; j++)
					{
						for (int i = 0; i < 1000; i++)
						{
							tempList.Add(r.Next(100));
						}
						//the rest of whaterver you're doing...
					}
				});
		}
