    from m in Db.Media
    join g in Db.Galleries on m.GalleryID equals g.GalleryID into MediaGalleries
    from mg in MediaGalleries.DefaultIfEmpty()
    where m.MediaDate >= DateTime.Today.AddDays(-30)
    orderby m.Views descending
    select new
    {
        GalleryTitle = mg != null ? mg.GalleryTitle : null,
        Media = m
    };
