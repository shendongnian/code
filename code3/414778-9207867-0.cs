    class YourClass
    {
         static readonly Dictionary<string, Func<DateTime, DateTime, bool>> s_filters = new Dictionary<string, Func<DateTime, DateTime, bool>>
         {
           {  ">", new Func<DateTime, DateTime, bool>((d1, d2) => d1  > d2) }
           { "==", new Func<DateTime, DateTime, bool>((d1, d2) => d1 == d2) }
           { "!=", new Func<DateTime, DateTime, bool>((d1, d2) => d1 != d2) }
           { ">=", new Func<DateTime, DateTime, bool>((d1, d2) => d1 >= d2) }
           { "<=", new Func<DateTime, DateTime, bool>((d1, d2) => d1 <= d2) }
         };
         public IEnumerable<Localisation> GetByFiltre(string filter, string valeurDate1)
         {
            ...
            DateTime dt = Convert.ToDateTime(valeurDate1);
            var filterDelegate = s_filters[filter];
            var mod = from o in new GpsContext().Locals.Where(loc => filterDelegate(loc.Date,dt));
            ...
         }
    }
