    myList = myList.OrderBy(d => d)
    .Aggregate(new List<string>(),  
        (list, item) => {
            if (!list.Any(x => item.StartsWith(x)))
                list.Add(item);
    
            return list;
        }).ToList();
