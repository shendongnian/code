		using (var context = new ModelContainer())
		{
			IQueryable<Advertiser> queryAdvertisers = 
				from c in context.Advertisers
				select c;
			for (int i = 0; i < 100; i++)
			{
				if (queryAdvertisers.Where(a => a.ID == i).Any())
				{
					Console.WriteLine("ID:{0} already exists.", i);
				}
				else
				{
					Console.WriteLine("ID:{0} does not exist.", i);
				}
			}
		}
