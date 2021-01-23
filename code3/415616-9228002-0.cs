    db.Articles.Where(a => a.PublicationDate  < db.Articles.Where(aa=>aa.Id==100)
                                                           .Select(aa=>aa.PublicationDate)
                                                           .SingleOrDefault() )
               .OrderByDescending(a=>a.PublicationDate)
               .Take(20);
