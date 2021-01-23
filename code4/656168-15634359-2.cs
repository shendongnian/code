      var Germany = new Countr();
      Germany.CountryName = "Germany";
      Germany.Regions = new List<CountryRegion>();
      var Siemensweg = new Area();
      Siemensweg.AreaName = "Siemensweg";
      Siemensweg.Population = 14;
      Germany.Regions.Add(new CountryRegion { RegionName = "FrankFurt", new List<Area> { Siemensweg });
