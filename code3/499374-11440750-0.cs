    var results = (from g in Galleries
	join m in Media
	on g.GalleryID equals m.GalleryID into mediaGrp
	select new
	{
		GalleryID = g.GalleryID,
		g.GalleryTitle,
		g.GalleryDate,
		MediaThumb = mediaGrp.First().MediaThumb
	}).Take(4).OrderByDescending (r => r.GalleryID);
