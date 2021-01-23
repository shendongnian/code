    var internationalDesksList =
                from internationalDesks in _context.InternationalDesks
                from subsection in _context.Subsections
                where subsection.PublicationId == 1 &&
                      (internationalDesks.EBALocationId == subsection.LocationId ||
                       internationalDesks.FELocationId == subsection.LocationId)
                select new {
                    internationalDesks.Id, 
                    subsection.LocationId
                };
