    var qry2 = from c in qry
        group c by c.Content.DownloadType into grouped
        select new ValueCount
        {
            Key = grouped.Key,
            Value = grouped.Count()
        }.AsEnumerable()   // This "cuts off" your method from the Entity Framework,
        .Select(vc => vc.ToKeyValuePair()); // letting you nicely complete the conversion in memory
