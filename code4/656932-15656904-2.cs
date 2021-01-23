     var sole = SoleService.All().Where(c => c.Status != 250)
                    .Select(x => new { 
                                    ID = x.ID, 
                                    Code = x.Code + x.Country, 
                                    Name = x.Name
                                    })
                    .Distinct()
                    .OrderBy(s => s.Code);
