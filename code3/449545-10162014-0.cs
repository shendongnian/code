    // I left this without changes
    if (emptyGroups.Count < 1)           
    {           
        characters.ForEach(x => emptyGroups.Add(new Group<Movies>(x, new List<Movies>())));           
    } 
    // I put var here, but it actually is an IQueryable<Movie>
    var query = from m in App.db.Movies orderby m.Title, m.Year select m;
 
    // Here var is IQueryable<anonymous type>, I just can't use anything else but var here
    var groupedMoviesQuery = from t in query
                        group t by t.GroupHeader into grp 
                        orderby grp.Key 
                        select new
                        {
                           Movies = grp,
                           Header = grp.Key
                        }; 
    // I use AsEnumerable to mark that what goes after AsEnumerable is to be executed on the client
    IEnumerable<Group<Movie>> groupedMovies = groupedMoviesQuery.AsEnumerable()
                                                .Select(x => new Group<Movie>(x.Header, x.Movies))
                                                .ToList();
    //No changes here
    moviesLongList.ItemsSource = (from t in groupedMovies.AsEnumerable().Union(emptyGroups)            
                                  orderby t.Title            
                                  select t).ToList(); 
