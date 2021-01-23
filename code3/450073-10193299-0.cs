    var groupedData = db.Form.Where(item=>item.CreatedDate > lastMonth && item.Name == "Test Name")
                        .OrderByDescending(item=>item.item.CreatedDate)
                        .GroupBy(item=>item.Record)
                        .Select(group => new {Groups = group, Key = group.Key, Count = group.Count()})
                        .Where(item => item.Groups.Any());
