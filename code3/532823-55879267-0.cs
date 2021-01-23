    public ActionResult Show1()
    {
        var query = from a in DB.Album
                    join b in DB.Artists
                    on a.ArtistId equals b.ArtistId
                    join c in DB.Genre
                    on a.GenreId equals c.GenreId
                    where (b.ArtistId == 2)
                    select new common { AlbumName = a.AlbumName, ArtistName = b.ArtistName, GenreName = c.GenreName /* ... other props */ };
        return View(query.ToList());
    }
    public class common
    {
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string GenreName { get; set; }
        //other props and not tables, use like string, int, decimal...
    }
