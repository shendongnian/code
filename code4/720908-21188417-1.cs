    interface IUserQuery {
      IEnumerable<string> RegionCodes { get; }
    }
    interface IRegionMapper {
      IEnumerable<Region> Get(IEnumerable<string> regionCodes);
    }
    interface IUserDisplay {
      void ShowResult(IEnumerable<Region> regions);
    }
