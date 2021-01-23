    public static class ChildrenGroupExtensions
    {
        public static List<CityInfo> GetChildren(this IEnumerable<IGrouping<string, City>> source, string parentName)
        {
            var cities = source.SingleOrDefault(g => g.Key == parentName);
            if (cities == null)
                return new List<CityInfo>();
            return cities.Select(c => new CityInfo { Name = c.Name, Children = source.GetChildren(c.Name) }).ToList();
        }
    }
