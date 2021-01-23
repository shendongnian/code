    // Main query, all other initialization code and types are below
    IEnumerable<string> titles = allMovies.SelectMany(l => 
        l.Where(sl => sl.Director == searchFor)
        .Select(m => m.Title));
 
    var dvds = new List<IMovie>
                    {
                        new DvdMovie {Title = "DVD1", Director = "Director1"},
                        new DvdMovie {Title = "DVD2", Director = "Director1"},
                        new DvdMovie {Title = "DVD3", Director = "Director2"}
                    };
    
    var bluerays = new List<IMovie>
                    {
                        new BlueRayMovie {Title = "BR1", Director = "Director3"},
                        new BlueRayMovie {Title = "BR2", Director = "Director3"},
                        new BlueRayMovie {Title = "BR3", Director = "Director1"}
                    };
    
    var allMovies = new List<IEnumerable<IMovie>> {dvds, bluerays};
    string searchFor = "Director1";
    // Main query
    IEnumerable<string> titles = allMovies.SelectMany(l => 
        l.Where(sl => sl.Director == searchFor)
        .Select(m => m.Title));
    // OUTPUT: DVD1, DVD2, BR3
