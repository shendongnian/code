    var Results = (from g in DB.Galleries
                   join m in DB.Media
                   on g.GalleryID equals m.GalleryID
                   group m by new { g.GalleryID, g.GalleryTitle, g.GalleryDate } into grp
                   orderby grp.Key.GalleryID descending
                   select new LatestGalleries
                   {
                       GalleryID = grp.Key.GalleryID,
                       GalleryTitle = grp.Key.GalleryTitle,
                       GalleryDate = grp.Key.GalleryDate,
                       MediaThumb = grp.FirstOrDefault().MediaThumb
                   });
