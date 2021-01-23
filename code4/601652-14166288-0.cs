    var Model = new GalleryViewModel
    {
        MediaID = MediaID,
        PictureGallery = Results
            .Select(r => new PictureGallery {
                GalleryID = r.Media.GalleryID,
                GalleryTitle = r.GalleryTitle,
                MediaID = r.Media.MediaID,
                ... // and so on
            }),
        PictureCount = Results.Count()
    };
