    var q = (from a in db.Galleries
            group a by new { a.GalleryID, a.GalleryTitle, a.GalleryDate } into g
            orderby g.Key.GalleryID descending
            select new
            {
                GalleryID = g.Key.GalleryID,
                GalleryTitle = g.Key.GalleryTitle,
                GalleryDate = g.Key.GalleryDate,
                MediaThumb = g.Max(a => a.Media) // Gallery.Media is a navigation property
            }).Take(4);
