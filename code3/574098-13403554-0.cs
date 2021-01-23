     var query = (from c in scope.Extent<cl>()
                         where  c.Date >= dateFrom && c.Date < dateTo
                         && c.Actions.Any(a => (a.comment== "") )
                         orderby c.Date.Value.Date
                         group c by c.Date.Value.Date into grpDate
                          select new { grpDate.Key, items = grpDate });
