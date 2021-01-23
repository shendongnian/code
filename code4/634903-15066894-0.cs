      DataTable dt = new DataTable();
      dt.Columns.Add("ID");
      dt.Columns.Add("Money", typeof(double));
      DataTable dt2 = new DataTable();
      dt2.Columns.Add("ID");
      dt2.Columns.Add("Money", typeof(double));
      dt.Rows.Add("1", 20.50);
      dt.Rows.Add("1", 20.50);
      dt.Rows.Add("2", 15.30);
      dt.Rows.Add("2", 10.70);
      var rows = dt.Rows.Cast<DataRow>().GroupBy(x => x["ID"]).Select(x => new { ID = x.Key, Money = x.Sum(row => row.Field<double>("Money")) });
      foreach (var row in rows)
      {
        dt2.Rows.Add(row.ID, row.Money);
      }
