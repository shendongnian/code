        public static IList<Application> CreatesApp(IEnumerable<string> names)
        {
          return names == null ? new List<Application>() : 
                 names.Select(name => new Application() { Name = name }).ToList();
        }
