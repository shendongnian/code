    var dic = (from claim in claims
               group claim by claim.Pages into pageGroup
               select new {
                   Page = pageGroup.Key,
                   Entries =
                       (from zentry in pageGroup
                        group zentry by zentry.Zip into zipGroup
                        select new {
                            Zip = zipGroup.Key,
                            Entries =
                                (from centry in zipGroup
                                 group centry by centry.Carrier into carrierGroup
                                 select new { Carrier = carrierGroup.Key, Entries = carrierGroup.AsEnumerable() })
                                .ToDictionary(ent => ent.Page, ent => ent.Entries)
                        }).ToDictionary(ent => ent.Page, ent => ent.Entries)
               }).ToDictionary(ent => ent.Page, ent => ent.Entries);
