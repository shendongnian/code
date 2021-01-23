    ...
    select new {
       rn.ReleaseTitle,
       plat.MediaPlatformName,
       pub.MediaPublisherName,
       c.CountryName,
       rd.ReleaseDateName,
       rd.ReleaseDate,
       a.AffiliateLinkAddress
    }).AsEnumerable() // <<== This forces the following Select to operate in memory
    .Select(t => {
       t.ReleaseTitle,
       t.MediaPlatformName,
       t.MediaPublisherName,
       t.CountryName,
       ReleaseDate = t.ReleaseDateName ?? t.ReleaseDate.ToString()
       t.AffiliateLinkAddress        
    }).ToList();
