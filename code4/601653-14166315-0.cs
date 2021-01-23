    //Query Results
    var Results = from g in DB.Galleries
                  join m in DB.Media on g.GalleryID equals m.GalleryID
                  where g.GalleryID == GalleryID
                  orderby m.MediaDate descending, m.MediaID descending
                  select new PictureGallery {
                                    GalleryID = g.GalleryId,
                                    GalleryTitle = g.GalleryTitle,
                                    MediaID = m.MediaID,
                                    MediaTitle = m.MediaTitle,
                                    MediaDesc = m.MediaDesc,
                                    Rating = m.Rating,
                                    Views = m.Views} ;
