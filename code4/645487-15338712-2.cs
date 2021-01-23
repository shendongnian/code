		private static void Main(string[] args)
		{
			var elements = new List<Container>
				{
					new Container {Id = 1, Start = new DateTime(2013, 3, 1, 18, 25, 26), Stop = new DateTime(2013, 3, 1, 18, 27, 29)},
					new Container {Id = 1, Start = new DateTime(2013, 3, 1, 18, 30, 26), Stop = new DateTime(2013, 3, 1, 18, 34, 29)},
					new Container {Id = 1, Start = new DateTime(2013, 3, 1, 18, 40, 26), Stop = new DateTime(2013, 3, 1, 18, 52, 29)},
					new Container {Id = 1, Start = new DateTime(2013, 3, 1, 18, 55, 26), Stop = new DateTime(2013, 3, 1, 18, 59, 29)},
				};
			foreach (Container container in DoMerge(elements, TimeSpan.FromMinutes(5)))
			{
				Console.WriteLine(container);
			}
			Console.ReadLine();
		}
