    var internationalDesksList =
                from internationalDesks in _context.InternationalDesks
                from subsection in _context.Subsections
                where ubsection.PublicationId == 1 &&
                      (internationalDesks.EBALocationId == s.LocationId ||
                       internationalDesks.FELocationId == s.LocationId)
                select new {
                    internationalDesks.Id, 
                    subsection.LocationId
                };
