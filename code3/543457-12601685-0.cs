    // build the new data table
    var result = new DataTable();
    result.Columns.Add("KundeID", typeof(Int32));
    result.Columns.Add("KundeName", typeof(String));
    result.Columns.Add("Comment", typeof(String));
    result.Columns.AddRange(
        (from c in 
             (from r in table.AsEnumerable() 
              where !r.IsNull("Produkt") && !string.IsNullOrEmpty(r.Field<string>("Produkt")) 
              select r.Field<string>("Produkt")) 
         select new DataColumn(c, typeof(bool))).ToArray()
    );
    foreach (var r in results)
    {
        var productIndex = result.Columns.IndexOf(r.Produkt);
        var vals = new List<object>() { r.KundeID, r.KundeName, r.Comment };
        for (int i = 3; i < result.Columns.Count; i++)
        {
            if (i == productIndex)
            {
                vals.Add(true);
            }
            else
            {
                vals.Add(false);
            }
        }
        result.LoadDataRow(vals.ToArray(), true);
    }
