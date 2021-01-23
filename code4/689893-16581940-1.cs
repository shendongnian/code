	class Land
	{
		public string Name { get; private set; }
		
		public Land(string name)
		{
			this.Name = name;
		}
	}
	class City
	{
		public string Name { get; private set; }
		public Land Land { get; private set; }
		public int Population { get; private set; }
			
		public City(string name, int population, Land land)
		{
			this.Name = name;
			this.Population = population;
			this.Land = land;
		}
	}
	class School
	{
		public string Name { get; private set; }
		public City City { get; private set; }
		
		public School(string name, City city)
		{
			this.Name = name;
			this.City = city;
		}
	}
