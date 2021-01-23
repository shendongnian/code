    list.GroupBy(item => item.RefId)
        .Select(grouping => new ListNew() {
               RefId = grouping.Key,
               RefName = grouping.First().RefName,
               ListGroup = grouping.Select(i => new Group() { ID = i.ID, Name = i.Name }).ToList()
         })
         .ToList();
                  
