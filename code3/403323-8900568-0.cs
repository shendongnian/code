    var qry = from c in db.XBLRegionalContents
        where c.PublishDate <= DateTime.Today
        group c by c.ContentId into grouped
        select new FeaturedViewModel {
            XBLRegionalContent = grouped.FirstOrDefault(x => x.ContentId == grouped.Key),
            RegionCount = grouped.Count()
        };
