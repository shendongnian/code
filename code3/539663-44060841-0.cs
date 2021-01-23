    list.OrderBy(x => {
                           var prop = x.GetType().GetProperty(sortFieldName);
                           return prop.GetValue(x);
                       });
    if (!isSortAsc) list.Reverse();
