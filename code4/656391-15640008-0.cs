    var results = contex.SiteUserContent
                        .Join(context.Specialties, suc => suc.SpecialtyId, s => s.SpecialtyId, (suc, s) => new { suc, s })
                        .Join(context.SiteUser, i = i.suc.SiteUserId, su => su.SiteUserId, (i, su) => new { suc = i.suc, s = i.s, su = su })
                        .Where(i => i.su.DeletedFlag == 0)
                        .GroupBy(i => i.s.SpecialtyName)
                        .Select(g => new {
                                         SpecialityName = g.Key,
                                         Subscribers = g.Select(i => i.suc.SiteUserId)
                                                        .Distinct()
                                                        .Count()
                                     })
                         .OrderBy(i => i.SpecialityName);
