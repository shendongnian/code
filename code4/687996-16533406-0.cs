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
       ReleaseTitle,
       MediaPlatformName,
       MediaPublisherName,
       CountryName,
       ReleaseDate = ReleaseDateName ?? ReleaseDate.ToString()
       a.AffiliateLinkAddress        
    }).ToList();
