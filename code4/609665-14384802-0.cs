    from m in Db.Media
                join g in Db.Galleries on m.GalleryID = g.GalleryID into MediaGalleries
                from mg in MediaGalleries.DefaultIfEmpty()
                orderby m.Views
                select new
                {
                    GalleryTitle = mg != null ? mg.GalleryTitle : null,
                    Media = m
                };
