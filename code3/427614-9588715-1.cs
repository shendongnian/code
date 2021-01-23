     DateTime zeroDate = new DateTime(2008, 1, 1, 0, 0, 0);
            this.ObjectContext.WMLSLogs.GroupBy(s => SqlFunctions.DateAdd("mi", ((SqlFunctions.DateDiff("mi", zeroDate, s.Date))), zeroDate)).
                Select(g => new
                    {
                        Date = g.Key,
                        count = g.Count()
                    }).OrderBy(x => x.Date);
