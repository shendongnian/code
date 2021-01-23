IEnumerable<Movie> allFilms = null;
using (var session = db4o.Ext().OpenSession())
{
    // query
    allFilms = from movie in session.Query<Movie>()
               select movie;
    
    // do object activation here or rely on default activation level
    foreach (var movie in allFilms)
    {
        session.Activate(movie, int.MaxValue);
    }
}
return View(allFilms);
