    var query = from table in navTable.AsEnumerable()
                group table by new
                {
                    Cat1Id = table["Cat1Id"], SalesOrg = table["SalesOrg"],
                    DistChan = table["DistChan"], Language = table["Language"]
                }
                into groupedTable
                where groupedTable.Select(x => x["Cat1Desc"]).Distinct().Count() > 1
                select new
                {
                    Cat1Count = groupedTable.Select(x => x["Cat1Desc"]).Distinct().Count(),
                    groupedTable.Key.Cat1Id, groupedTable.Key.SalesOrg,
                    groupedTable.Key.DistChan, groupedTable.Key.Language
                };
