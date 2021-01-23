    SoleColorService.All()
                    .AsEnumerable()
                    .GroupBy(x => x.SoleCode)
                    .Select(g => g.First())
                    .ToList();
