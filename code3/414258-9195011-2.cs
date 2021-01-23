    var groups = table.AsEnumerable().
                       GroupBy(row => row.Field<DateTime>("Date")).
                       Select(group => new 
                       { 
                         Date = group.Key, 
                         Quantity = group.Sum(item => item.Qty),
                         Price = group.Sum(item => item.Qty * item.Price)
                       });
