    var grouped = (from s in stocks
                    group s by new { s.Id, s.LocationId }
                        into grp
                        select new Stock()
                        {
                            Id = grp.Key.Id,
                            LocationId = grp.Key.LocationId,
                            Quantity = grp.Sum(x => x.Quantity)
                        }).ToList();
