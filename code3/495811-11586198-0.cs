    var query =
        from band in Context.Band
        join album in Context.Albums on album.BandID equals band.BandID into j1
        from j2 in j1.Where(x => x.SomeOtherKey == value).DefaultIfEmpty()
        select new BandWithAlbumModel
        {
            Band = band,
            Album = j2
        };
  
    public class BandWithAlbumModel
    {
         public Band Band { get; set; }
         public Album Album { get; set; }
    }
