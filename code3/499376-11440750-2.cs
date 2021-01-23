    var results = (from g in Galleries
	join m in Media
	on g.GalleryID equals m.GalleryID 
	group m by new { g.GalleryID, g.GalleryTitle, g.GalleryDate } into grp
	orderby grp.Key.GalleryID descending
	select new
	{
		grp.Key.GalleryID,
		grp.Key.GalleryTitle,
		grp.Key.GalleryDate,
		MediaThumb = grp.First().MediaThumb
	}).Take(4);
