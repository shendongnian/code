    var allAsString = table.AsEnumerable()
        .Select((r, ri) => new
        {
            Row = r,
            RowNumber = ri,
            Fields = r.ItemArray.Select((f, i) => new 
            {
                Col = table.Columns[i],
                FieldText = string.Format("{0}", f)
            })
        });
