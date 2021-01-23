    class WeekComparer : IComparer<Config>
    {
        public int Compare(Config x, Config y)
        { 
            return string.Compare(x.Name, 5, y.Name, 5, int.MaxValue); 
        }
    }
    // using System.Linq;
    var weekComparer = new WeekComparer();
    ConfigLists = ConfigLists.OrderBy(x => x, weekComparer).ToList();
