    DataTable result = dtDealerTotal.Clone();
    result.Columns.Add(new DataColumn("HandTotal", typeof(UInt16)));
    var dealers = dtDealerTotal.AsEnumerable();
    foreach (var x in query)
    {
        foreach (var d in dealers.Where(dr => dr.Field<UInt16>("SpotID") == x.SpotID))
        {
            var fields = d.ItemArray;
            fields.Concat(new Object[] { x.HandTotal });
            result.Rows.Add(fields);
        }
    }
