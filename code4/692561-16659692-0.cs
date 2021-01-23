    Newtonsoft.Json.JsonConvert.SerializeObject(
     dataTable.Select(
      d => new {
       Names = d.Columns.Select(c => c.ColumnName).ToArray(),
       Values = d.Rows.Select(r => r.ToArray()).ToArray()
      })
    );
