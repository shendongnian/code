            var queryResults = from iso in query
                               orderby iso.Artikelnummer ascending
                               group iso by new { iso.Artikelnummer, iso.Retourenkopfdaten.Retourengrund } into isoGroup
                               select new RetourenNeu()
                               {
                                   Artikel = isoGroup.Key.Artikelnummer,
                                   Retourengrund = isoGroup.Key.Retourengrund.HasValue ? isoGroup.Key.Retourengrund.Value : 0,
                                   Anzahl = isoGroup.Select(v => v.Anzahl).Sum()
                               };
                var neu = (from n in queryResults
                       group n by n.Artikel into source
                       select new RetourenPivot()
                       {
                           Artikel = source.Key,
                           Retourengrund = source.Select(s => s.Retourengrund),
                           Anzahl = source.Select(s => s.Anzahl)
                       }).ToList();
