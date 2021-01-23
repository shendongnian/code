    (
      from a in galleries
      join b in media on b.GalleryID equals a.GalleryID
      group by new {a.GalleryID, a.GalleryTitle, a.GalleryDate} into grouping
      order by grouping.Key.GalleryID
      select new {grouping.Key.GalleryID, grouping.Key.GalleryTitle, grouping.Key.GalleryDate, grouping.Max(x=>x.MediaThumb)}
    ).Take(4)
