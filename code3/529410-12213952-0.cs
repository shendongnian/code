    var movieResponse = MovieListRootObject
                        .SelectMany(m => new {
                           id = m.Response.Id,
                           title = m.Response.Title,
                           description = m.Response.Description
                        });
