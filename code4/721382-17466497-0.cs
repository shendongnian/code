       dt2Lookup = new HashSet(
           dt2.AsEnumerable().Select(row => row.Field<int>("Id")));
       dt3 = dt1.Clone();
       forreach (var row In dt1.AsEnumerable())
       {
          var newRow = dt3.Rows.Add(row.ItemArray)
          if (dt2lookup.Contains(row.Field<int>("Id"))
          {
               newRow.SetField("Name", string.Empty);
          }
       }
