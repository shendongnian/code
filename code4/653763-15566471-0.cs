    SoleColorService.All()
                    .GroupBy(t => t.Sole.Code)
                    .Select(g => g.First())
                    .Select(x => new
                    {
                        SoleCode = x.Sole.Code,
                        SoleName = x.Sole.Name),
                        SoleId   = x.SoleID)
                    }); 
