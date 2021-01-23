    var viewData = phdetail.Skip(rows*(page-1)).Take(rows).Select((p, index) 
        => new TableRow {
            id = index + 1,
            cell = new List<string> {
                p.PhoneNumber,  p.UpdateDate, p.UpdateTime
            }
        }).ToArray();
