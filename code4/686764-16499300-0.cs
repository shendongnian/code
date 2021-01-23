    var results = 
        from row in lDTSalesOrder
        group row by row.Field<string>("SKU") into grp
        orderby grp.Key
        select new
        {
            SKU = grp.Key,
            Quantity = grp.Sum(r => r.Field<double>("Quantity")),
            UnitPrice = grp.Sum(r => r.Field<double>("UnitPrice")),
            LinePrice = grp.Sum(r => r.Field<double>("LinePrice"))
        };
