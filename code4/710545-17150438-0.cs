    var compareGenres = listGenres.Genres.Select(gl => gl.IdGenre).ToList();
    var matchingMovies = myContext.Movies.Where(m =>
                                            m.Genres.Join(compareGenres,
                                                          g => g.IdGenre,
                                                          cg => cg.IdGenre,
                                                          (g, cg) => g
                                                         ).Any());
