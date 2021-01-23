    GalleryMedias
    .Where(q => q.Gallery.Status == 1 && q.Media.Status == 1 && q.Media.MediaTypeId==1)
     .Select(q => new
    {
       Id = q.Gallery.Id,
       Title = q.Gallery.Title,
       MediaTypeId = q.Media.MediaTypeId,
       GalleryMedia = q //Here you are including the GalleryMedia object in your annonymous object
     }
    )
    .GroupBy(g => g.GalleryMedia.Property) //You can now access the GalleryMedia's properties in the GroupBy
    .OrderByDescending(q=>q.Id)
