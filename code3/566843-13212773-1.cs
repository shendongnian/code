    public BindingList<Movie> Search(string title, int? year, int? rating)
    {
        var matches = movieCollection.AddSearchParameter(!string.IsNullorEmpty(title), m=>m.Title == title);
        matches = matches.AddSearchParameter(year.HasValue, m=>m.Year == year.Value);
        matches = matches.AddSearchParameter(rating.HasValue, m=>m.rating >= rating.Value);
    
        // do some other stuff with the matches
    }
