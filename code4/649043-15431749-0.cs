    [TestFixture]
	public class CitiesTest
	{
		[Test]
		public void Test()
		{
			var strings = new List<string>
				{
					"Alberton;Johannesburg",
					"Allendale;Phoenix",
					"Brackenhurst;Alberton",
					"Cape Town;",
					"Durban;",
					"Johannesburg;",
					"Mayville;Durban",
					"Phoenix;Durban",
					"Sandton;Johannesburg"
				};
			//===================================================
			var allAreas = strings.SelectMany(x=>x.Split(';')).Where(x=>!string.IsNullOrWhiteSpace(x)).Distinct().ToDictionary(x=>x, x=>new Area{Name = x});
			strings.ForEach(area =>
				{
					var areas = area.Split(';');
					if (string.IsNullOrWhiteSpace(areas[1]))
						return;
					var childArea = allAreas[areas[0]];
					if (!allAreas[areas[1]].Children.Contains(childArea))
						allAreas[areas[1]].Children.Add(childArea);
					childArea.IsParent = false;
				});
			var result = allAreas.Select(x=>x.Value).Where(x => x.IsParent);
			//===================================================
		}
		public class Area
		{
			public string Name;
			public bool IsParent;
			public List<Area> Children { get; set; }
			public Area()
			{
				Children = new List<Area>();
				IsParent = true;
			}
		}
	}
